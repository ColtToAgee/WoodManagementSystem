using FluentValidation;

namespace WoodManagementSystem.Application.Features.Users.Command.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommandRequest>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().MaximumLength(60).MinimumLength(8).EmailAddress().WithName("Email");
            RuleFor(x => x.Password).NotEmpty().MaximumLength(50).MinimumLength(6).WithName("Şifre");
        }
    }
}
