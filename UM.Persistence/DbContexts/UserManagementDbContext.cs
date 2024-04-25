using UM.Domain.Aggregates.OutboxMessage;
using UM.Domain.Aggregates.User;
using UM.Domain.Aggregates.User.Entities;

namespace UM.Persistence.DbContexts
{
    public partial class UserManagementDbContext(DbContextOptions<UserManagementDbContext> options)
        : DbContext(options), IUserManagementDbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<OutboxMessage> OutboxMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserManagementDbContext).Assembly);

            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData([
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Customer" }]);

            // complex types are not yet supported in seeding, so PasswordSalt and PasswordHash fields has to be set manually in migration file

            modelBuilder.Entity<User>().HasData(new
            {
                Id = 1,
                RoleId = 1,
                Name = "Davit",
                Email = "dato.gugushvili@gmail.com",
                IsDeleted = false,
                CreateDate = new DateTimeOffset(new DateTime(2024, 01, 01)),
                CreatorId = 1
            });
        }
    }
}