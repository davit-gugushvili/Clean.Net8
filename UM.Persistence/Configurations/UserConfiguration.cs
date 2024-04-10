using UM.Domain.Aggregates.User;

namespace UM.Persistence.Configurations
{
    internal partial class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("User");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.ComplexProperty(o => o.Password, e =>
            {
                e.Property(x => x.Salt).HasColumnName("PasswordSalt")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                e.Property(x => x.Hash).HasColumnName("PasswordHash")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            entity.HasOne(d => d.Creator).WithMany(p => p.InverseCreator).HasForeignKey(d => d.CreatorId);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<User> entity);
    }
}
