using Microsoft.Extensions.DependencyInjection;
using UM.Persistence.DbContexts;
using UM.Persistence.Interceptors;
using UM.Persistence.Options;

namespace UM.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, ConnectionStringOptions options)
        {
            if (string.IsNullOrEmpty(options?.UserManagement))
                throw new ArgumentNullException("Connection string can't be null");

            services.AddSingleton<PublishDomainEventsInterceptor>();
            services.AddSingleton<SoftDeleteInterceptor>();

            services.AddDbContext<UserManagementDbContext>((serviceProvider, builder) => builder
                .UseSqlServer(options.UserManagement)
                .AddInterceptors(serviceProvider.GetRequiredService<PublishDomainEventsInterceptor>())
                .AddInterceptors(serviceProvider.GetRequiredService<SoftDeleteInterceptor>()));

            services.AddScoped<IUserManagementDbContext, UserManagementDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
