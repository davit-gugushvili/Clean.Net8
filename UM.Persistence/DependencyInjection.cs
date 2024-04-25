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
                throw new ArgumentNullException("Connection String Can't Be Null");

            //services.AddScoped<PublishDomainEventsInterceptor>();
            services.AddTransient<OutboxMessageInterceptor>();
            services.AddScoped<SoftDeleteInterceptor>();
            services.AddScoped<AuditableInterceptor>();

            services.AddDbContext<UserManagementDbContext>((serviceProvider, builder) => builder
                .UseSqlServer(options.UserManagement)
                //.AddInterceptors(serviceProvider.GetRequiredService<PublishDomainEventsInterceptor>())
                .AddInterceptors(serviceProvider.GetRequiredService<OutboxMessageInterceptor>())
                .AddInterceptors(serviceProvider.GetRequiredService<SoftDeleteInterceptor>())
                .AddInterceptors(serviceProvider.GetRequiredService<AuditableInterceptor>()));

            services.AddScoped<IUserManagementDbContext, UserManagementDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
