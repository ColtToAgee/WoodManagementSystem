using MediatR;
using WoodManagementSystem.Application.DTOs;

namespace WoodManagementSystem.Application.Features.Carts.Queries.GetTemplateCustomerCart
{
    public class GetTemplateCustomerCartQueryRequest : IRequest<GetTemplateCustomerCartQueryResponse>
    {
        public IList<TemplateCustomerCartDto>? CustomerCartItems { get; set; }
        public int? PatternId { get; set; }
    }
}
