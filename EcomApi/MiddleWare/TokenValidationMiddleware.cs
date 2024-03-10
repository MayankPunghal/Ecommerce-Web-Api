﻿using EcomApi.DataEntities.Models.TokenValidation;
using EcomApi.Services;
using EcomApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

public class TokenValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JwtSettings _jwtSettings;

    public TokenValidationMiddleware(RequestDelegate next, IOptions<JwtSettings> jwtSettings)
    {
        _next = next;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task Invoke(HttpContext context)
    {
        var excludedPaths = new[] { "/api/1/users/loginbyusername", "/api/1/users/loginbyemail", "/api/1/general/checkhealth", "/api/1/general/generatetoken", "/api/1/users/registeruser" };

        // Check if the request path is in the excluded paths
        if (excludedPaths.Contains(context.Request.Path.Value))
        {
            await _next(context);
            return;
        }

        var authorizationHeader = context.Request.Headers["Authorization"];

        // Check if the Authorization header is missing or empty
        if (string.IsNullOrEmpty(authorizationHeader))
        {
            // Return an "Invalid Token" response
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid Token");
            return;
        }

        // Remove quotes from the token
        var token = authorizationHeader.ToString().Replace("Bearer ", "").Replace("\"", "");
        var key = Encoding.ASCII.GetBytes(AppSettings.Settings.Jwt.SecretKey);

        // Validate the token
        try
        {
            var principal = new JwtSecurityTokenHandler().ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero,
                ValidAudiences = AppSettings.Settings.Jwt.Audience
        }, out _);

            var endpoint = context.GetEndpoint();
            if (endpoint != null)
            {
                var authorizeAttributes = endpoint.Metadata.GetOrderedMetadata<AuthorizeAttribute>();
                if (authorizeAttributes.Any())
                {
                    var authorizationService = context.RequestServices.GetRequiredService<IAuthorizationService>();
                    foreach (var authorizeAttribute in authorizeAttributes)
                    {
                        // Check if the user has the required roles for the policy
                        var authorizationResult = await authorizationService.AuthorizeAsync(principal, authorizeAttribute.Policy);
                        if (!authorizationResult.Succeeded)
                        {
                            context.Response.StatusCode = 403; // Forbidden
                            await context.Response.WriteAsync("Your role doesn't have access to perform this action.");
                            return;
                        }
                    }
                }
            }

            // Attach the user principal to the context for later use
            context.User = principal;
        }
        catch
        {
            // Token validation failed, handle accordingly
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        await _next(context);
    }
}
