namespace UM.Application.Features.Users.Queries.GetUsers
{
    public sealed record GetUsersQuery : Pagination, IRequest<Result<PaginatedList<UserDto>>>
    {
    }
}
