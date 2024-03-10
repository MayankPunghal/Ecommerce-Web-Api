using EcomApi.DataEntities.Models.TokenValidation;
using Microsoft.OpenApi.Models;
using EcomApi.Utils;
using EcomApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
void ConfigureServices(IServiceCollection services)
{
    // Other service configurations
    var configuration = builder.Configuration;
    services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
    services.AddLogging(logging =>
    {
        logging.AddConsole();
        logging.AddDebug();
    });
    // Inside ConfigureServices method in Startup.cs

}

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Admin"));
    // Add more policies as needed
});

//builder.Services.AddSingleton<ITokenBlacklistService, TokenBlacklistService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EcomWebApi", Version = "v1" });
//});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EcomWebApi", Version = "v1" });

    // Define the security scheme
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter your JWT token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",  // This should match the scheme used in TokenValidationMiddleware
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    // Define the security requirement
    var securityRequirement = new OpenApiSecurityRequirement
    {
        { securityScheme, new List<string>() }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(securityRequirement);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestLoggingMiddleware>();
if(AppSettings.Settings.Jwt.IsAuthenticationOn)
{
    app.UseMiddleware<TokenValidationMiddleware>();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder.WithOrigins("http://localhost:3000")
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials());

app.UseAuthorization();
app.MapControllers();
app.Run();
