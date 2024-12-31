using MediatR;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Carts.Command.AddCartItem
{
    public class AddCartItemCommandRequest : IRequest<AddCartItemCommandResponse>
    {
        public IList<CustomerCartItem> CustomerCartItems { get; set; }
    }
}
