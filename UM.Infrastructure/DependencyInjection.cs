using Microsoft.Extensions.DependencyInjection;
using UM.Infrastructure.Auth;
using UM.Infrastructure.Services;

namespace UM.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
