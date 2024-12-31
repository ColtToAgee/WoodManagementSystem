using MediatR;

namespace WoodManagementSystem.Application.Features.Orders.Command.DeleteOrder
{
    public class DeleteOrderCommandRequest : IRequest<DeleteOrderCommandResponse>
    {
        public int Id { get; set; } 
    }
}
