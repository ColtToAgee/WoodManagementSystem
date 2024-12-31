using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodManagementSystem.Application.Interfaces.AutoMapper;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Patterns.Queries.GetAllPatterns
{
    public class GetAllPatternsQueryHandler : IRequestHandler<GetAllPatternsQueryRequest, IList<GetAllPatternsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllPatternsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllPatternsQueryResponse>> Handle(GetAllPatternsQueryRequest request, CancellationToken cancellationToken)
        {
            var patterns = await unitOfWork.GetReadRepository<Pattern>().GetAllAsync();
            var map = mapper.Map<GetAllPatternsQueryResponse,Pattern>(patterns);

            return map;
        }
    }
}
