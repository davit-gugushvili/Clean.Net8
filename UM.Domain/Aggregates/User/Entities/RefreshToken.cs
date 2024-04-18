namespace UM.Domain.Aggregates.User.Entities
{
    public partial class RefreshToken
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Token { get; set; } = string.Empty;

        public DateTimeOffset? ExpireDate { get; set; }

        public virtual User? User { get; set; }
    }
}