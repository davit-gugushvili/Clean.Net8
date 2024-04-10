namespace UM.Application.Features.Users.Queries.GetUsers
{
    internal sealed class GetUsersQueryHandler(IUserManagementDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetUsersQuery, Result<PaginatedList<UserDto>>>
    {
        public async Task<Result<PaginatedList<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await mapper.ProjectTo<UserDto>(dbContext.Users.OrderByDescending(x => x.Id))
                .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);

            return Result.Success(users);
        }
    }
}