using UM.Domain.Aggregates.User;
using UM.Domain.Aggregates.User.Specifications;
using UM.Domain.Aggregates.User.ValueObjects;

namespace UM.Application.Features.Users.Commands.UpdateUser
{
    internal sealed class UpdateUserCommandHandler(IRepository<User> userRepository) 
        : IRequestHandler<UpdateUserCommand, Result>
    {
        public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var password = Password.Create(request.Password);

            if (password.IsFailure)
                return Result.Failure(password);

            var spec = new UserSpecification(request.Id);

            var user = await userRepository.FirstOrDefaultAsync(spec, cancellationToken);

            if (user == null)
                return Result.Failure(Errors.UserNotFound);

            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = password.Value!;
            user.RoleId = request.RoleId;

            await userRepository.UpdateAsync(user, cancellationToken);

            return Result.Success();
        }
    }
}