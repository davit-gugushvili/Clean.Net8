using UM.Domain.Aggregates.User.Entities;

namespace UM.Persistence.Configurations
{
    internal partial class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> entity)
        {
            entity.ToTable("Role");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(1);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(2);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Role> entity);
    }
}
