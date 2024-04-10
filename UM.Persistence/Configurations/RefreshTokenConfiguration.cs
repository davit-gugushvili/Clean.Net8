using UM.Domain.Aggregates.User.Entities;

namespace UM.Persistence.Configurations
{
    internal partial class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> entity)
        {
            entity.ToTable("RefreshToken");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Token)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RefreshToken_User");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<RefreshToken> entity);
    }
}
