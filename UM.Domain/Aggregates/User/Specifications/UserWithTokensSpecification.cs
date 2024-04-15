namespace UM.Domain.Aggregates.User.Specifications
{
    public sealed class UserWithTokensSpecification : SingleResultSpecification<User>
    {
        public UserWithTokensSpecification(int id)
        {
            Query.Include(x => x.Tokens).Where(x => x.Id == id);
        }
    }
}