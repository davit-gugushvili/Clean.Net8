using MediatR;
using UM.SharedKernel.Common;

namespace UM.Persistence.Interceptors
{
    public class PublishDomainEventsInterceptor(IMediator mediator) 
        : SaveChangesInterceptor
    {
        public override ValueTask<int> SavedChangesAsync(
            SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            if (eventData.Context == null)
            {
                return base.SavedChangesAsync(eventData, result, cancellationToken);
            }

            var domainEvents = eventData.Context.ChangeTracker.Entries<Entity>().Select(x => x.Entity).SelectMany(x =>
            {
                var domainEvents = x.DomainEvents.ToList();

                x.ClearDomainEvents();

                return domainEvents;
            }).ToList();

            foreach (var item in domainEvents)
            {
                mediator.Publish(item);
            }

            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }
    }
}
