namespace UM.Application.Features.Users.Queries.GetUserById
{
    internal sealed class GetUserByIdQueryHandler(IUserManagementDbContext dbContext, IMapper mapper) 
        : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
    {
        public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await mapper.ProjectTo<UserDto>(dbContext.Users.Include(x => x.Role))
                .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (user == null)
                return Result.Failure(ErrorMessages.UserNotFound);

            return Result.Success(user);
        }
    }
}
