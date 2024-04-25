using System.Text.Json.Serialization;
using UM.Domain.Aggregates.User.Entities;
using UM.Domain.Aggregates.User.ValueObjects;

namespace UM.Domain.Aggregates.User
{
    public partial class User : Entity, IAggregateRoot, IAuditable, ISoftDelible
    {
        public int RoleId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public required Password Password { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public int CreatorId { get; set; }

        public virtual User? Creator { get; set; }

        public DateTimeOffset? LastModifyDate { get; set; }

        public int? LastModifierId { get; set; }

        public virtual User? LastModifier { get; set; }

        public virtual ICollection<User> InverseCreator { get; set; } = new List<User>();

        public virtual ICollection<User> InverseLastModifier { get; set; } = new List<User>();

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

        public virtual Role? Role { get; set; }
    }
}