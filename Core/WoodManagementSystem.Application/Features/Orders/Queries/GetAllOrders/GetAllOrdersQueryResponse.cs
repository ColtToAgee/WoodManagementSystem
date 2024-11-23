using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryResponse
    {
        public int PatternId { get; set; }
        public bool IsPaid { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime PaidDate { get; set; }
        ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
