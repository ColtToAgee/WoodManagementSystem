using FluentValidation;

namespace WoodManagementSystem.Application.Features.Carts.Command.DeleteCartItem
{
    public class DeleteCartItemCommandValidator : AbstractValidator<DeleteCartItemCommandRequest>
    {
        public DeleteCartItemCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
