using FluentValidation;

namespace WoodManagementSystem.Application.Features.Orders.Command.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommandRequest>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.PatternId).NotEmpty();
            RuleFor(x => x.CreatedUserId).NotEmpty();
            RuleFor(x => x.OrderDetails).NotEmpty();
        }
    }
}
