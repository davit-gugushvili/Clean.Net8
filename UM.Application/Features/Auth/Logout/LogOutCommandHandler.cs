using UM.Domain.Aggregates.User;
using UM.Domain.Aggregates.User.Specifications;

namespace UM.Application.Features.Auth.Login
{
    internal sealed class LogOutCommandHandler(IRepository<User> userRepository, ICurrentUser currentUser)
        : IRequestHandler<LogOutCommand, Result>
    {
        public async Task<Result> Handle(LogOutCommand request, CancellationToken cancellationToken)
        {
            var spec = new UserWithRefreshTokensSpecification(currentUser.Id!.Value);

            var user = await userRepository.SingleOrDefaultAsync(spec, cancellationToken);

            if (user == null)
                return Result.Failure(ErrorMessages.UserNotFound);

            var refreshToken = user.RefreshTokens.FirstOrDefault(x => x.Token == request.RefreshToken);

            if (refreshToken == null)
                return Result.Failure(ErrorMessages.UserNotFound);

            user.RefreshTokens.Remove(refreshToken);

            await userRepository.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
