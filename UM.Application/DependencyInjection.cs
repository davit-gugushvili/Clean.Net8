using Microsoft.Extensions.DependencyInjection;
using UM.Application.Features.Auth.Login;
using UM.Application.Features.Users.Commands.CreateUser;

namespace UM.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddAutoMapper(assembly);

            services.AddValidatorsFromAssembly(assembly);

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(assembly);

                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>), ServiceLifetime.Transient);

                config.AddValidationBehavior<LogInCommand, LogInCommandDto>();
                config.AddValidationBehavior<RefreshQuery, string>();
                config.AddValidationBehavior<CreateUserCommand, int>();
            });

            return services;
        }
    }
}
