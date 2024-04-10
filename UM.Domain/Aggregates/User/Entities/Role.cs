namespace UM.Domain.Aggregates.User.Entities
{
    public partial class Role : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}