using UM.Domain.Aggregates.User.Entities;
using UM.Domain.Aggregates.User.ValueObjects;

namespace UM.Domain.Aggregates.User;

public partial class User : Entity, IAggregateRoot, ISoftDelible
{
    public int RoleId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public required Password Password { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreateDate { get; set; }

    public int? CreatorId { get; set; }

    public virtual User? Creator { get; set; }

    public virtual ICollection<User> InverseCreator { get; set; } = new List<User>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();

    public virtual Role? Role { get; set; }
}