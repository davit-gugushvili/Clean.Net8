using UM.Domain.Aggregates.OutboxMessage;
using UM.Domain.Aggregates.User;
using UM.Domain.Aggregates.User.Entities;

namespace UM.Application.Interfaces
{
    public interface IUserManagementDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<RefreshToken> RefreshTokens { get; set; }
        DbSet<OutboxMessage> OutboxMessages { get; set; }
    }
}
