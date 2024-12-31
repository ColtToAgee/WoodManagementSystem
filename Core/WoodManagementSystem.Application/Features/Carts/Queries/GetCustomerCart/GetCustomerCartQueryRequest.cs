using MediatR;

namespace WoodManagementSystem.Application.Features.Carts.Queries.GetCustomerCart
{
    public class GetCustomerCartQueryRequest : IRequest<GetCustomerCartQueryResponse>
    {
        public int CustomerUserId { get; set; }
    }
}
