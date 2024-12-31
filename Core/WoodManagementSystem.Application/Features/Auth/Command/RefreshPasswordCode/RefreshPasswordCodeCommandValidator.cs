using FluentValidation;

namespace WoodManagementSystem.Application.Features.Auth.Command.GenerateRefreshPasswordCode
{
    public class RefreshPasswordCodeCommandValidator : AbstractValidator<RefreshPasswordCodeCommandRequest>
    {
        public RefreshPasswordCodeCommandValidator()
        {
            RuleFor(a => a.Email).NotEmpty().EmailAddress();
        }
    }
}
