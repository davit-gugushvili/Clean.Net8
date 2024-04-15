using UM.Domain.Aggregates.User;
using UM.Domain.Aggregates.User.Specifications;

namespace UM.Application.Features.Auth.Login
{
    internal sealed class LogOutCommandHandler(IRepository<User> userRepository, ICurrentUser currentUser)
        : IRequestHandler<LogOutCommand, Result>
    {
        public async Task<Result> Handle(LogOutCommand request, CancellationToken cancellationToken)
        {
            var spec = new UserWithTokensSpecification(currentUser.Id);

            var user = await userRepository.SingleOrDefaultAsync(spec, cancellationToken);

            if (user == null)
                return Result.Failure(ErrorMessages.UserNotFound);

            var refreshToken = user.Tokens.FirstOrDefault(x => x.RefreshToken == request.RefreshToken);

            if (refreshToken == null)
                return Result.Failure(ErrorMessages.UserNotFound);

            user.Tokens.Remove(refreshToken);

            await userRepository.UpdateAsync(user, cancellationToken);

            return Result.Success();
        }
    }
}
