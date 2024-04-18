using UM.Domain.Aggregates.User.Entities;
using UM.Domain.Aggregates.User.ValueObjects;

namespace UM.Application.Features.Auth.Login
{
    internal sealed class LogInCommandHandler(IUserManagementDbContext dbContext, IRepository<RefreshToken> refreshTokenRepository, IJwtProvider jwtProvider)
        : IRequestHandler<LogInCommand, Result<LogInCommandDto>>
    {
        public async Task<Result<LogInCommandDto>> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users.Include(x => x.Role)
                .Select(x => new { x.Id, Role = x.Role!.Name, x.Name, x.Email, x.Password }).FirstOrDefaultAsync();

            if (user == null)
                return Result.Failure(Errors.UserNotFound);

            var passwordResult = Password.Create(user.Password!.Salt, request.Password);

            if (passwordResult.IsFailure)
                return Result.Failure(passwordResult);

            if (user.Password != passwordResult.Value!)
                return Result.Failure(AuthErrors.InvalidCredentials);

            var accessToken = jwtProvider.GenerateAccessToken(user.Id, user.Role);

            var refreshToken = jwtProvider.GenerateRefreshToken();

            await refreshTokenRepository.AddAsync(new RefreshToken
            {
                UserId = user.Id,
                Token = refreshToken
            });

            return Result.Success(new LogInCommandDto(user.Name, user.Email, user.Role, accessToken, refreshToken));
        }
    }
}
