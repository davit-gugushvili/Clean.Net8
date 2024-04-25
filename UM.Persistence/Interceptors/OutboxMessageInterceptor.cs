using Newtonsoft.Json;
using UM.Domain.Aggregates.OutboxMessage;

namespace UM.Persistence.Interceptors
{
    public class OutboxMessageInterceptor(ICurrentUser currentUser, TimeProvider timeProvider)
        : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            if (eventData.Context != null)
            {
                var domainEvents = eventData.Context.ChangeTracker.Entries<Entity>().Select(x => x.Entity).SelectMany(x =>
                {
                    var domainEvents = x.DomainEvents.ToList();

                    x.ClearDomainEvents();

                    return domainEvents;
                }).ToList();

                var outboxMessages = domainEvents.Select(x => new OutboxMessage
                {
                    Name = x.GetType().Name,
                    Content = JsonConvert.SerializeObject(x),
                    CreateDate = timeProvider.GetLocalNow(),
                    CreatorId = currentUser.Id
                });

                eventData.Context.Set<OutboxMessage>().AddRange(outboxMessages);
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
