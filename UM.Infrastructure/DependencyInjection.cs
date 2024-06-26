﻿using FastEndpoints.Security;
using Microsoft.Extensions.DependencyInjection;
using UM.Infrastructure.Security;
using UM.Infrastructure.Security.Jwt;
using UM.Infrastructure.Services;

namespace UM.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, JwtOptions options)
        {
            services
                .AddAuthenticationJwtBearer(x => x.SigningKey = options.SecretKey)
                .AddAuthorization(x => x.AddPolicy("AdminsOnly", x => x.RequireRole("Admin")));

            services.AddScoped<ICurrentUser, CurrentUser>();

            services.AddSingleton<IJwtProvider, JwtProvider>();
            services.AddSingleton<IEmailService, EmailService>();

            return services;
        }
    }
}
