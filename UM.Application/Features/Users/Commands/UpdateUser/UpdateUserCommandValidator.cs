namespace UM.Application.Features.Users.Commands.UpdateUser
{
    public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator(IUserManagementDbContext _dbContext)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress().DependentRules(() =>
            {
                When(x => x.Id > 0, () =>
                {
                    RuleFor(x => new { x.Id, x.Email })
                        .MustAsync(async (p, _) =>
                        {
                            return !await _dbContext.Users.AnyAsync(x => x.Email == p.Email && x.Id != p.Id);
                        })
                        .WithMessage(UserErrors.EmailAlreadyExists.ErrorMessage)
                        .WithErrorCode(UserErrors.EmailAlreadyExists.ErrorCode)
                        .OverridePropertyName(nameof(UpdateUserCommand.Email));
                });
            });
            RuleFor(x => x.Password).NotEmpty().Password();
            RuleFor(x => x.RoleId).NotEmpty();
        }
    }
}
