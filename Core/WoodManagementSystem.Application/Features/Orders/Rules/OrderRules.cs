using WoodManagementSystem.Application.Bases;
using WoodManagementSystem.Application.Features.Orders.Exceptions;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Orders.Rules
{
    public class OrderRules : BaseRules
    {
        public Task OrderIsNotFound(Order order)
        {
            if (order is null) throw new OrderIsNotFoundException();
            return Task.CompletedTask;
        }

    }
}
