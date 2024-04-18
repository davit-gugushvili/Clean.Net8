namespace UM.SharedKernel.Interfaces
{
    public interface IAuditable
    {
        DateTimeOffset CreateDate { get; set; }
        int CreatorId { get; set; }
        DateTimeOffset? LastModifyDate { get; set; }
        int? LastModifierId { get; set; }
    }
}
