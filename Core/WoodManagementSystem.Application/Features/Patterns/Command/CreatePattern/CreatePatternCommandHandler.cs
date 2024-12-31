using MediatR;
using WoodManagementSystem.Application.Features.Patterns.Rules;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Patterns.Command.CreatePattern
{
    public class CreatePatternCommandHandler : IRequestHandler<CreatePatternCommandRequest, CreatePatternCommandResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PatternRules patternRules;

        public CreatePatternCommandHandler(IUnitOfWork unitOfWork, PatternRules patternRules)
        {
            this.unitOfWork = unitOfWork;
            this.patternRules = patternRules;
        }
        public async Task<CreatePatternCommandResponse> Handle(CreatePatternCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Pattern> patterns = await unitOfWork.GetReadRepository<Pattern>().GetAllAsync();
            await patternRules.PatternNameMustNotBeSame(patterns, request.PatternName);

            Pattern newPattern = new Pattern(request.PatternName, request.Width, request.Height, request.Cost);
            var response = new CreatePatternCommandResponse();
            await unitOfWork.GetWriteRepository<Pattern>().AddAsync(newPattern);
            if (await unitOfWork.SaveAsync() > 0)
            {
                response.IsSuccess = true;
                response.Message = "Kalıp Başarıyla Eklendi";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Kalıp Eklenemedi";
            }
            return response;
        }
    }
}
