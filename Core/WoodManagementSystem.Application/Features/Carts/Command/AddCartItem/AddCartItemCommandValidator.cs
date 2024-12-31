using FluentValidation;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Carts.Command.AddCartItem
{
    public class AddCartItemCommandValidator : AbstractValidator<AddCartItemCommandRequest>
    {
        public AddCartItemCommandValidator()
        {
            RuleFor(x => x.CustomerCartItems).NotEmpty().ForEach(x => x.SetValidator(new CustomerCartItemValidator()));
        }
    }
    public class CustomerCartItemValidator : AbstractValidator<CustomerCartItem>
    {
        public CustomerCartItemValidator()
        {
            RuleFor(x => x.CustomerCartId).NotEmpty();
            RuleFor(x => x.PatternId).NotEmpty();
            RuleFor(x => x.DimensionWidth).NotEmpty().WithName("Genişlik");
            RuleFor(x => x.DimensionLength).NotEmpty().WithName("Yükseklik");
        }
    }
}
