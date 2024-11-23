using MediatR;

namespace WoodManagementSystem.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryRequest:IRequest<IList<GetAllOrdersQueryResponse>>
    {
    }
}
