using DesafioAda.DataAccess;
using DesafioAda.DependencyInjection;
using FastEndpoints;
using FastEndpoints.Swagger;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;
using Serilog.Events;
using Microsoft.EntityFrameworkCore;
using DesafioAda.Exceptions;

namespace DesafioAda;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Serilog.ILogger logger = new LoggerConfiguration()
                     .Enrich.FromLogContext()
                     .WriteTo.Console()
            .CreateLogger();

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        // Add services to the container.
        builder.Services.AddFastEndpoints();
        builder.Services.AddSerilog(logger);
        builder.Services.SwaggerDocument();
        builder.Services.AddDbContext<CardContext>(options =>
                   options.UseInMemoryDatabase("CardInMemoryDb"));

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
        builder.Services.AddScoped<ICardRepository, CardRepository>();

        var app = builder.Build();

        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<ExceptionMiddleware>();

        app.UseFastEndpoints(x =>
        {
            x.Errors.ResponseBuilder = (failures, statusCode, alo) =>
            {
                return new
                {
                    Errors = failures.Select(x => x.ErrorMessage).ToList()
                };
            };
        });

        app.UseOpenApi();
        app.UseSwaggerUi3(x => x.ConfigureDefaults());

        app.Run();
    }
}