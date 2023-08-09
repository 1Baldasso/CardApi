using DesafioAda.Services.Abstractions;
using DesafioAda.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DesafioAda.DependencyInjection;

public static class JwtServiceCollectionExtensions
{
    public static IServiceCollection AddAuthService(this IServiceCollection services, string jwtSecret)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret))
            };
        });
        services.AddScoped<ITokenService>((p) => new TokenService(jwtSecret));
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}
