using UM.Domain.Aggregates.User;
using UM.Domain.Aggregates.User.Entities;
using UM.Domain.Aggregates.User.Specifications;
using UM.Domain.Aggregates.User.ValueObjects;

namespace UM.Application.Features.Auth.Login
{
    internal sealed class LogInCommandHandler(IRepository<User> userRepository, IJwtProvider jwtProvider)
        : IRequestHandler<LogInCommand, Result<LogInCommandDto>>
    {
        public async Task<Result<LogInCommandDto>> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            var spec = new UserWithRoleSpecification(request.Email);

            var user = await userRepository.SingleOrDefaultAsync(spec, cancellationToken);

            if (user == null)
                return Result.Failure(ErrorMessages.UserNotFound);

            var passwordResult = Password.Create(user.Password!.Salt, request.Password);

            if (passwordResult.IsFailure)
                return Result.Failure(passwordResult);

            if (user.Password != passwordResult.Value!)
                return Result.Failure(ErrorMessages.InvalidCredentials);

            var accessToken = jwtProvider.GenerateAccessToken(user.Id, user.Role!.Name);

            var refreshToken = jwtProvider.GenerateRefreshToken();

            user.RefreshTokens.Add(new RefreshToken
            {
                Token = refreshToken
            });

            await userRepository.SaveChangesAsync(cancellationToken);

            return Result.Success(new LogInCommandDto
            {
                Name = user.Name,
                Email = user.Email,
                Role = user.Role.Name,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }
    }
}
