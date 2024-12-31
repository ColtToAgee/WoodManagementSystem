using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodManagementSystem.Application.DTOs;
using WoodManagementSystem.Application.Features.Carts.Rules;
using WoodManagementSystem.Application.Features.Patterns.Rules;
using WoodManagementSystem.Application.Interfaces.Algorithms;
using WoodManagementSystem.Application.Interfaces.AutoMapper;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Carts.Queries.GetTemplateCustomerCart
{
    public class GetTemplateCustomerCartQueryHandler : IRequestHandler<GetTemplateCustomerCartQueryRequest, GetTemplateCustomerCartQueryResponse>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IBinPackingAlgorithmService binPackingAlgorithmService;
        private readonly CartItemRules cartItemRules;
        private readonly PatternRules patternRules;

        public GetTemplateCustomerCartQueryHandler(IMapper mapper,IUnitOfWork unitOfWork, IBinPackingAlgorithmService binPackingAlgorithmService,CartItemRules cartItemRules,PatternRules patternRules)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.binPackingAlgorithmService = binPackingAlgorithmService;
            this.cartItemRules = cartItemRules;
            this.patternRules = patternRules;
        }
        public async Task<GetTemplateCustomerCartQueryResponse> Handle(GetTemplateCustomerCartQueryRequest request, CancellationToken cancellationToken)
        {
            var layoutList = new List<Layout>();
            var sizes = new List<CustomerCartItem>();
            var pattern = await unitOfWork.GetReadRepository<Pattern>().GetAsync(a => a.Id == request.PatternId);
            await patternRules.PatternIsNotFound(pattern);
            foreach(var cartItems in request.CustomerCartItems)
            {
                var item = await unitOfWork.GetReadRepository<CustomerCartItem>().GetAsync(a => a.Id == cartItems.Id);
                await cartItemRules.CartItemIsNotFound(item);
                sizes.Add(item);
            }
            var layouts = binPackingAlgorithmService.Pack(sizes, pattern, layoutList);
            var response = new GetTemplateCustomerCartQueryResponse()
            {
                LayoutList = layouts,
            };
            return response;
        }
    }
}
