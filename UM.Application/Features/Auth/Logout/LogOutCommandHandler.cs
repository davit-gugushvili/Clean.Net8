using UM.Domain.Aggregates.User.Entities;
using UM.Domain.Aggregates.User.Specifications;

namespace UM.Application.Features.Auth.Login
{
    internal sealed class LogOutCommandHandler(IRepository<RefreshToken> refreshTokenRepository, ICurrentUser currentUser)
        : IRequestHandler<LogOutCommand, Result>
    {
        public async Task<Result> Handle(LogOutCommand request, CancellationToken cancellationToken)
        {
            var specification = new RefreshTokenSpecification(currentUser.Id, request.RefreshToken);

            var refreshToken = await refreshTokenRepository.SingleOrDefaultAsync(specification);

            if (refreshToken == null)
                return Result.Failure(AuthErrors.RefreshTokenNotFound);

            await refreshTokenRepository.DeleteAsync(refreshToken);

            return Result.Success();
        }
    }
}
