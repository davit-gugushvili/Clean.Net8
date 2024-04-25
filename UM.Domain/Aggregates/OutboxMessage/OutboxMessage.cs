namespace UM.Domain.Aggregates.OutboxMessage
{
    public sealed class OutboxMessage
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTimeOffset CreateDate { get; set; }
        public int CreatorId { get; set; }
        public DateTimeOffset? ProcessDate { get; set; }
        public string? Error { get; set; }
    }
}
