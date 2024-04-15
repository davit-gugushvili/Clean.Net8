using UM.Domain.Aggregates.User;
using UM.Domain.Aggregates.User.Entities;
using UM.Persistence.Configurations;
using UM.Persistence.Interceptors;

namespace UM.Persistence.DbContexts
{
    public partial class UserManagementDbContext(DbContextOptions<UserManagementDbContext> options)
        : DbContext(options), IUserManagementDbContext
    {
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TokenConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}