using EcomApi.DataEntities.Models;
using EcomApi.DataEntities.Models.TokenValidation;
using EcomApi.Helpers;
using EcomApi.Services;
using EcomApi.Utils;
using EcomApi.Utils.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcomApi.Controllers
{
    public class GeneralController : Controller
    {

        [HttpGet]
        [Route(ApiRoute.general.checkhealth)]
        public IActionResult CheckHealth()
        {
            return Ok(new { Status = "ok" });
        }
        [HttpPost]
        [Route(ApiRoute.general.generatetoken)]
        public IActionResult GenerateToken(string username, string role)
        {
            var token = GenerateJwtToken(username, role);
            if(token != null && token.Length > 0)
                return Ok(token);
            return BadRequest("Token Could Not Be Generated");
            //return Ok(GenerateJwtToken(username));
        }

        public string GenerateJwtToken(string username, string role)
        {
            try
            {
                var secretKey = AppSettings.Settings.Jwt.SecretKey;
                var issuer = AppSettings.Settings.Jwt.Issuer;
                var audience = AppSettings.Settings.Jwt.Audience;
                var expirationMinutes = Convert.ToInt32(AppSettings.Settings.Jwt.ExpirationMinutes);

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
        new Claim(ClaimTypes.Name, username),
        new Claim(ClaimTypes.Role, role)
        // Add more claims as needed
    };

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
                    signingCredentials: credentials
                );
                return new (new JwtSecurityTokenHandler().WriteToken(token) + ", " +expirationMinutes.ToString());
            }
            catch (Exception ex)
            {
                Log.Error($"Error in GenerateToken : {ex}");
                return null;
            }

        }

    }
}
