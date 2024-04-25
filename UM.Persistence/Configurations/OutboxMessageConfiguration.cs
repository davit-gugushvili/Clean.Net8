using UM.Domain.Aggregates.OutboxMessage;

namespace UM.Persistence.Configurations
{
    internal partial class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> entity)
        {
            entity.ToTable("OutboxMessage");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnOrder(1);

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnOrder(2);

            entity.Property(e => e.Content)
                .IsUnicode(false)
                .HasColumnOrder(3);

            entity.Property(e => e.CreateDate)
                .HasColumnOrder(4);

            entity.Property(e => e.CreatorId)
                .HasColumnOrder(5);

            entity.Property(e => e.ProcessDate)
                .HasColumnOrder(6);

            entity.Property(e => e.Error)
                .HasColumnOrder(7);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<OutboxMessage> entity);
    }
}
