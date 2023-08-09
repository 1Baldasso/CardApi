using DesafioAda.DependencyInjection;
using DesafioAda.Services.Abstractions;
using DesafioAda.Services.Implementations;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

namespace DesafioAda;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        // Add services to the container.
        builder.Services.AddFastEndpoints();
        builder.Services.SwaggerDocument();

        builder.Services.AddCors(options =>
            options.AddDefaultPolicy(policy => 
                policy.AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod()));

        builder.Services.AddAuthorization();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAuthService(config["JwtSecret"]);
        builder.Services.AddScoped<ICardRepository, FakeCardRepository>();

        var app = builder.Build();

        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseFastEndpoints(x => x.Errors.ResponseBuilder = (failures, statusCode, alo) =>
        {
            return new
            {
                Errors = failures.Select(x => x.ErrorMessage).ToList()
            };
        });

        app.UseOpenApi();
        app.UseSwaggerUi3(x => x.ConfigureDefaults());

        app.Run();
    }
}