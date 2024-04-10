namespace UM.Domain.Aggregates.User.Specifications
{
    public sealed class UserWithRoleSpecification : SingleResultSpecification<User>
    {
        public UserWithRoleSpecification(string email)
        {
            Query.Include(x => x.Role).Where(x => x.Email == email);
        }
    }
}