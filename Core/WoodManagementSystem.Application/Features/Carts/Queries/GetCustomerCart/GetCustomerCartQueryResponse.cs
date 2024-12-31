using WoodManagementSystem.Application.DTOs;

namespace WoodManagementSystem.Application.Features.Carts.Queries.GetCustomerCart
{
    public class GetCustomerCartQueryResponse
    {
        public double TotalCost { get; set; }
        public bool IsOrdered { get; set; }
        public IList<CustomerCartItemDto> CustomerCartItems { get; set; }
    }
}
