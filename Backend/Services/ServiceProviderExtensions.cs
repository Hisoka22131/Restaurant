using System;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text;
using Backend.Services.CustomServices;
using Backend.Services.Interfaces;
using Core.Domain.Base;
using Core.RepositoryPattern.GenericRepository;
using Core.RepositoryPattern.UoF;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Backend.Services;

public static class ServiceProviderExtensions
{
    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        return services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        return services.AddScoped<IDistrictService, DistrictService>()
            .AddScoped<IClientService, ClientService>()
            .AddScoped<IDeliveryManService, DeliveryManService>()
            .AddScoped<IDishService, DishService>()
            .AddScoped<IOrderService, OrderService>()
            .AddScoped<IAuthService, AuthService>();
    }

    /// <summary>
    /// JWT
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddCustomAuthService(this IServiceCollection services,
        IConfiguration configuration)
    {
        var secretKey = configuration.GetSection("AppSettings:Key").Value;

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = key
                };
            });
        return services;
    }

    /// <summary>
    /// Аутентификация и авторизация в сваггере
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCustomSwaggerGen(this IServiceCollection services)
    {
        return services.AddSwaggerGen(q =>
        {
            q.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant", Version = "v1" });
            q.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Description = "JWT Authorization",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });
            q.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }
}