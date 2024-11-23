using MediatR;
using WoodManagementSystem.Application.Interfaces.AutoMapper;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, IList<GetAllOrdersQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetAllOrdersQueryResponse>> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = await unitOfWork.GetReadRepository<Order>().GetAllAsync();
            var map = mapper.Map<GetAllOrdersQueryResponse, Order>(orders);

            return map;
        }
    }
}
