namespace UM.SharedKernel.Abstractions
{
    public interface ISoftDelible
    {
        bool IsDeleted { get; set; }
    }
}
