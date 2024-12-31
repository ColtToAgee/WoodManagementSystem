using FluentValidation;
using WoodManagementSystem.Application.Bases;

namespace WoodManagementSystem.Application.Features.Orders.Command.DeleteOrder
{
    public class DeleteOrderCommandValidator:AbstractValidator<DeleteOrderCommandRequest>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
