namespace UM.Persistence.Interceptors
{
    public class AuditableInterceptor(ICurrentUser currentUser, TimeProvider timeProvider)
        : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            if (eventData.Context != null)
            {
                foreach (var entry in eventData.Context.ChangeTracker.Entries<IAuditable>())
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.CreateDate = timeProvider.GetLocalNow();
                        entry.Entity.CreatorId = currentUser.Id;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entry.Entity.LastModifyDate = timeProvider.GetLocalNow();
                        entry.Entity.LastModifierId = currentUser.Id;
                    }
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
