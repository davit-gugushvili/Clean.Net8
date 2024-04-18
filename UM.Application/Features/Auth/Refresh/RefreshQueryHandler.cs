namespace UM.Application.Features.Auth.Login
{
    internal sealed class RefreshQueryHandler(
        IUserManagementDbContext dbContext, ICurrentUser currentUser, IJwtProvider jwtProvider, TimeProvider timeProvider)
        : IRequestHandler<RefreshQuery, Result<string>>
    {
        public async Task<Result<string>> Handle(RefreshQuery request, CancellationToken cancellationToken)
        {
            var refreshToken = await dbContext.RefreshTokens.Include(x => x.User).ThenInclude(x => x!.Role)
                .Where(x => x.UserId == currentUser.Id && x.Token == request.RefreshToken)
                .Select(x => new { x.UserId, UserRole = x.User!.Role!.Name, x.ExpireDate }).SingleOrDefaultAsync();

            if (refreshToken == null)
                return Result.Failure(AuthErrors.RefreshTokenNotFound);

            if (refreshToken.ExpireDate != null && refreshToken.ExpireDate < timeProvider.GetLocalNow())
                return Result.Failure(AuthErrors.RefreshTokenExpired);

            var accessToken = jwtProvider.GenerateAccessToken(refreshToken.UserId, refreshToken.UserRole);

            return Result.Success(accessToken);
        }
    }
}
