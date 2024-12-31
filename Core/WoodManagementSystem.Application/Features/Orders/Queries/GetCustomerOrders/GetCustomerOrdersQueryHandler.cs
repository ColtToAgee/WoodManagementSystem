using MediatR;
using WoodManagementSystem.Application.DTOs;
using WoodManagementSystem.Application.Interfaces.AutoMapper;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Orders.Queries.GetCustomerOrders
{
    public class GetCustomerOrdersQueryHandler : IRequestHandler<GetCustomerOrdersQueryRequest, IList<GetCustomerOrdersQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetCustomerOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetCustomerOrdersQueryResponse>> Handle(GetCustomerOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = await unitOfWork.GetReadRepository<Order>().GetAllAsync(x => x.CreatedUserId == request.CustomerUserId);
            var orderDetail = mapper.Map<OrderDetailDto, OrderDetails>(new OrderDetails());
            var map = mapper.Map<GetCustomerOrdersQueryResponse, Order>(orders);

            return map;
        }
    }
}
