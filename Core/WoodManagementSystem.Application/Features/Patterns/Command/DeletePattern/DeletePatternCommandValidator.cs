using FluentValidation;

namespace WoodManagementSystem.Application.Features.Patterns.Command.DeletePattern
{
    public class DeletePatternCommandValidator : AbstractValidator<DeletePatternCommandRequest>
    {
        public DeletePatternCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
