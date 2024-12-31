using FluentValidation;

namespace WoodManagementSystem.Application.Features.Patterns.Command.CreatePattern
{
    public class CreatePatternCommandValidator : AbstractValidator<CreatePatternCommandRequest>
    {
        public CreatePatternCommandValidator()
        {
            RuleFor(x => x.Width).NotEmpty().WithName("Genişlik");
            RuleFor(x => x.Height).NotEmpty().WithName("Yükseklik");
            RuleFor(x => x.Cost).NotEmpty().WithName("Fiyat");
        }
    }
}
