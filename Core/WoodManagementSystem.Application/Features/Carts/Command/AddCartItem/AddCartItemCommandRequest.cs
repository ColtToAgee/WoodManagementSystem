using MediatR;
using WoodManagementSystem.Application.DTOs;

namespace WoodManagementSystem.Application.Features.Carts.Command.AddCartItem
{
    public class AddCartItemCommandRequest : IRequest<AddCartItemCommandResponse>
    {
        public IList<CustomerCartItemDto> CustomerCartItems { get; set; }
    }
}
