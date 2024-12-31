using MediatR;

namespace WoodManagementSystem.Application.Features.Carts.Command.DeleteCartItem
{
    public class DeleteCartItemCommandRequest : IRequest<DeleteCartItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
