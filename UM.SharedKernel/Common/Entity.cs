using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UM.SharedKernel.Common
{
    public abstract class Entity
    {
        public int Id { get; set; }

        private readonly List<IDomainEvent> _domainEvents = [];

        [NotMapped]
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
