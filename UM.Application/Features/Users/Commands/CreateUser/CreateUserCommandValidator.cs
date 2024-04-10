namespace UM.Application.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(IUserManagementDbContext _dbContext)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MustAsync(async (email, _) =>
                {
                    return !await _dbContext.Users.AnyAsync(x => x.Email == email);
                }).WithMessage(ErrorMessages.EmailAlreadyExists.ErrorMessage).WithErrorCode(ErrorMessages.EmailAlreadyExists.ErrorCode);
            RuleFor(x => x.Password).NotEmpty().Password();
            RuleFor(x => x.RoleId).NotEmpty();
        }
    }
}
