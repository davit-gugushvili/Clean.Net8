using UM.Domain.Aggregates.User.Entities;

namespace UM.Domain.Aggregates.User.Specifications
{
    public sealed class RefreshTokenSpecification : SingleResultSpecification<RefreshToken>
    {
        public RefreshTokenSpecification(int userId, string token)
        {
            Query.Where(x => x.UserId == userId && x.Token == token);
        }
    }
}