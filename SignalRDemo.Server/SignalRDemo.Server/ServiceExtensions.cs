using System.Reflection;
using System.Text;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SignalRDemo.Server.Commands;
using SignalRDemo.Server.Data;
using SignalRDemo.Server.Helpers;
using SignalRDemo.Server.Infrastructure.Validation;
using SignalRDemo.Server.Models;

namespace SignalRDemo.Server;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfiguredIdentity(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddIdentityCore<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DeclarationsDbContext>();

        var issuer = config.GetIssuer();
        var audience = config.GetAudience();
        var key = config.GetTokenGenerationKey();

        services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            });

        services.AddAuthorization(options =>
        {
            options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
        });

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        AddDbContext(services);

        services.AddValidatorsFromAssemblyContaining<CreateDeclaration>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(CreateDeclaration).Assembly);
        });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<>));

        return services;
    }

    private static void AddDbContext(IServiceCollection services)
    {
        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "declarations.db");
        var connection = new SqliteConnection(@$"Data Source={dbPath}");
        services.AddDbContext<DeclarationsDbContext>(options => options.UseSqlite(connection));
    }
}