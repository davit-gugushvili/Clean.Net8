using UM.Domain.Aggregates.User;

namespace UM.Domain.Events
{
    public sealed class UserCreatedDomainEvent(User user)
        : IDomainEvent
    {
        public User User { get; } = user;
    }
}
