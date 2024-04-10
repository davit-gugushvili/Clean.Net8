namespace UM.Domain.Aggregates.User.Specifications
{
    public sealed class UserWithRefreshTokensSpecification : SingleResultSpecification<User>
    {
        public UserWithRefreshTokensSpecification(int id)
        {
            Query.Include(x => x.RefreshTokens).Where(x => x.Id == id);
        }
    }
}