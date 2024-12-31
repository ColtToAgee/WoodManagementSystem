using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Orders.Queries.GetCustomerOrders
{
    public class GetCustomerOrdersQueryResponse
    {
        public int PatternId { get; set; }
        public bool IsCancelled { get; set; }
        IList<OrderDetails> OrderDetails { get; set; }
    }
}
