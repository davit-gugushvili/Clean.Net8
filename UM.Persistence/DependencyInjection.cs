using Microsoft.Extensions.DependencyInjection;
using UM.Persistence.DbContexts;
using UM.Persistence.Options;
using UM.Persistence.Repositories;

namespace UM.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, ConnectionStringOptions options)
        {
            if (string.IsNullOrEmpty(options?.UserManagement))
                throw new ArgumentNullException("Connection string can't be null");

            services.AddDbContext<UserManagementDbContext>(x => x.UseSqlServer(options.UserManagement));

            services.AddScoped<IUserManagementDbContext, UserManagementDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
