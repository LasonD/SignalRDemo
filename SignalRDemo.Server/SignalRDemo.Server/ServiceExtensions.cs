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
using Microsoft.OpenApi.Models;
using SignalRDemo.Server.Api.Middleware;
using SignalRDemo.Server.Application.Models;
using SignalRDemo.Server.Application.Services;
using SignalRDemo.Server.Application.UseCases.Commands;
using SignalRDemo.Server.Common.Helpers;
using SignalRDemo.Server.Infrastructure.Data;
using SignalRDemo.Server.Infrastructure.Validation;

namespace SignalRDemo.Server;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfiguredIdentity(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddIdentityCore<User>(options =>
            {
                options.Password = new PasswordOptions
                {
                    RequireDigit = false,
                    RequiredLength = 4,
                    RequireLowercase = false,
                    RequireUppercase = false,
                    RequireNonAlphanumeric = false,
                };
            })
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
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        if (!accessToken.IsNullOrEmpty())
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });

        services.AddAuthorization(options =>
        {
            options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
        });

        services.AddCors(options =>
        {
            options.AddPolicy(Constants.AllowAllCorsPolicy, builder => builder
                .WithOrigins(config["AllowedOrigin"]!)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            ); 
        });
        services.AddEndpointsApiExplorer();

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<INotificationsService, NotificationsService>();
        services.AddTransient<ICache<string, List<string>>, InMemoryCache<string, List<string>>>();
        services.AddTransient<ICache<string, string>, InMemoryCache<string, string>>();
        services.AddTransient<IDeclarationsLockManager, DeclarationsLockManager>();

        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddScoped<ErrorHandler>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddSignalR();

        AddDbContext(services);

        services.AddValidatorsFromAssemblyContaining<CreateDeclaration.Command>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(config => { config.RegisterServicesFromAssembly(typeof(CreateDeclaration).Assembly); });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "JWTToken_Auth_API",
                Version = "v1"
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description =
                    "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        return services;
    }

    private static void AddDbContext(IServiceCollection services)
    {
        var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "declarations.db");
        var connection = new SqliteConnection(@$"Data Source={dbPath}");
        services.AddDbContext<DeclarationsDbContext>(options => options.UseSqlite(connection));
    }
}