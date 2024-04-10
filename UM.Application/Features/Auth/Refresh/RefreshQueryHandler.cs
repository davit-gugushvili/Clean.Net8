namespace UM.Application.Features.Auth.Login
{
    internal sealed class RefreshQueryHandler(IUserManagementDbContext dbContext, ICurrentUser currentUser, IJwtProvider jwtProvider)
        : IRequestHandler<RefreshQuery, Result<string>>
    {
        public async Task<Result<string>> Handle(RefreshQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users.Include(x => x.Role).Include(x => x.RefreshTokens).Select(x => new
            {
                x.Id,
                Role = x.Role!.Name,
                IsRefreshTokenValid = x.RefreshTokens.Any(x => x.Token == request.RefreshToken)
            }).FirstOrDefaultAsync(x => x.Id == currentUser.Id!.Value, cancellationToken);

            if (user == null)
                return Result.Failure(ErrorMessages.UserNotFound);

            if (!user.IsRefreshTokenValid)
                return Result.Failure(ErrorMessages.RefreshTokenNotFound);

            var accessToken = jwtProvider.GenerateAccessToken(user.Id, user.Role);

            return Result.Success(accessToken);
        }
    }
}
