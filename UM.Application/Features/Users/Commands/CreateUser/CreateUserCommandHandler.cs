﻿using UM.Domain.Aggregates.User;
using UM.Domain.Aggregates.User.ValueObjects;

namespace UM.Application.Features.Users.Commands.CreateUser
{
    internal sealed class CreateUserCommandHandler(IRepository<User> userRepository)
        : IRequestHandler<CreateUserCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordResult = Password.Create(request.Password);

            if (passwordResult.IsFailure)
                return Result.Failure(passwordResult);

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = passwordResult.Value!,
                RoleId = request.RoleId
            };

            user.AddDomainEvent(new UserCreatedDomainEvent(user));

            await userRepository.AddAsync(user, cancellationToken);

            return Result.Success(user.Id);
        }
    }
}
