using UM.Domain.Aggregates.User;
using UM.Domain.Aggregates.User.Specifications;

namespace UM.Application.Features.Users.Commands.DeleteUser
{
    internal sealed class DeleteUserCommandHandler(IRepository<User> userRepository)
        : IRequestHandler<DeleteUserCommand, Result>
    {
        public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var spec = new UserSpecification(request.Id);

            var user = await userRepository.FirstOrDefaultAsync(spec, cancellationToken);

            if (user == null)
                return Result.Failure(Errors.UserNotFound);

            await userRepository.DeleteAsync(user, cancellationToken);

            return Result.Success();
        }
    }
}
