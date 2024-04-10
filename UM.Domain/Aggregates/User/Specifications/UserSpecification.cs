namespace UM.Domain.Aggregates.User.Specifications
{
    public sealed class UserSpecification : SingleResultSpecification<User>
    {
        public UserSpecification(int id)
        {
            Query.Where(x => x.Id == id);
        }
    }
}