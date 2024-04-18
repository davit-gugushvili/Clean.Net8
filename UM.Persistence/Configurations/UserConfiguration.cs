using UM.Domain.Aggregates.User;

namespace UM.Persistence.Configurations
{
    internal partial class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("User");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnOrder(1);

            entity.Property(e => e.RoleId)
                .HasColumnOrder(2);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnOrder(3);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(4);

            entity.ComplexProperty(o => o.Password, e =>
            {
                e.Property(x => x.Salt).HasColumnName("PasswordSalt")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnOrder(5);

                e.Property(x => x.Hash).HasColumnName("PasswordHash")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnOrder(6);
            });

            entity.Property(e => e.IsDeleted)
                .HasColumnOrder(7);

            entity.Property(e => e.CreateDate)
                .HasColumnOrder(8);

            entity.Property(e => e.CreatorId)
                .HasColumnOrder(9);

            entity.Property(e => e.LastModifyDate)
                .HasColumnOrder(10);

            entity.Property(e => e.LastModifierId)
                .HasColumnOrder(11);

            entity.HasOne(d => d.Creator)
                .WithMany(p => p.InverseCreator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("FK_User_User_Creator");

            entity.HasOne(d => d.LastModifier)
                .WithMany(p => p.InverseLastModifier)
                .HasForeignKey(d => d.LastModifierId)
                .HasConstraintName("FK_User_User_LastModifier");

            entity.HasOne(d => d.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<User> entity);
    }
}
