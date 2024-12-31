using WoodManagementSystem.Application.Bases;
using WoodManagementSystem.Application.Features.Carts.Exceptions;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Carts.Rules
{
    public class CartItemRules : BaseRules
    {
        public Task CartItemIsNotFound(CustomerCartItem cartItem)
        {
            if (cartItem is null) throw new CartItemIsNotFound();
            return Task.CompletedTask;
        }
    }
}
