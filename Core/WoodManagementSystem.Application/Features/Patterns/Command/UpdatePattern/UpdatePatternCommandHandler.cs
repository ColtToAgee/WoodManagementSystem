using MediatR;
using WoodManagementSystem.Application.Features.Patterns.Rules;
using WoodManagementSystem.Application.Interfaces.AutoMapper;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Patterns.Command.UpdatePattern
{
    public class UpdatePatternCommandHandler : IRequestHandler<UpdatePatternCommandRequest, UpdatePatternCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly PatternRules patternRules;

        public UpdatePatternCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, PatternRules patternRules)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.patternRules = patternRules;
        }
        public async Task<UpdatePatternCommandResponse> Handle(UpdatePatternCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdatePatternCommandResponse();
            var pattern = await unitOfWork.GetReadRepository<Pattern>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            await patternRules.PatternIsNotFound(pattern);

            var map = mapper.Map<Pattern, UpdatePatternCommandRequest>(request);

            await unitOfWork.GetWriteRepository<Pattern>().UpdateAsync(map);
            if (await unitOfWork.SaveAsync() > 0)
            {
                response.IsSuccess = true;
                response.Message = "Kalıp Başarıyla Güncellendi";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Kalıp Güncellenemedi";
            }
            return response;
        }
    }
}
