using UM.Domain.Aggregates.User;

namespace UM.Domain.Events
{
    public sealed class UserCreatedDomainEvent(User user) 
        : DomainEventBase
    {
        public User User { get; } = user;
    }
}
