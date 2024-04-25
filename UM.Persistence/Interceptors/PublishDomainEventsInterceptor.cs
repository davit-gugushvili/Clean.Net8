//using MediatR;

//namespace UM.Persistence.Interceptors
//{
//    public class PublishDomainEventsInterceptor(IPublisher publisher)
//        : SaveChangesInterceptor
//    {
//        public override ValueTask<int> SavedChangesAsync(
//            SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
//        {
//            if (eventData.Context != null)
//            {
//                var domainEvents = eventData.Context.ChangeTracker.Entries<Entity>().Select(x => x.Entity).SelectMany(x =>
//                {
//                    var domainEvents = x.DomainEvents.ToList();

//                    x.ClearDomainEvents();

//                    return domainEvents;
//                }).ToList();

//                foreach (var item in domainEvents)
//                {
//                    publisher.Publish(item);
//                }
//            }

//            return base.SavedChangesAsync(eventData, result, cancellationToken);
//        }
//    }
//}
