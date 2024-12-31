using FluentValidation;

namespace WoodManagementSystem.Application.Features.Patterns.Command.UpdatePattern
{
    public class UpdatePatternCommandValidator : AbstractValidator<UpdatePatternCommandRequest>
    {
        public UpdatePatternCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Width).NotEmpty().WithName("Genişlik");
            RuleFor(x => x.Height).NotEmpty().WithName("Yükseklik");
            RuleFor(x => x.Cost).NotEmpty().WithName("Fiyat");
        }
    }
}
