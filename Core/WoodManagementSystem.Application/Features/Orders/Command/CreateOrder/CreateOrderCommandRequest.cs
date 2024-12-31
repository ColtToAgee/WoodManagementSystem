using MediatR;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Orders.Command.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public int PatternId { get; set; }
        public int CreatedUserId { get; set; }
        public IList<OrderDetails> OrderDetails { get; set; }
    }
}
