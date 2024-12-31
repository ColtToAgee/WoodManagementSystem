using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodManagementSystem.Application.Features.Patterns.Rules;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Patterns.Command.DeletePattern
{
    public class DeletePatternCommandHandler : IRequestHandler<DeletePatternCommandRequest, DeletePatternCommandResposne>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PatternRules patternRules;

        public DeletePatternCommandHandler(IUnitOfWork unitOfWork,PatternRules patternRules)
        {
            this.unitOfWork = unitOfWork;
            this.patternRules = patternRules;
        }
        public async Task<DeletePatternCommandResposne> Handle(DeletePatternCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new DeletePatternCommandResposne();
            var pattern = await unitOfWork.GetReadRepository<Pattern>().GetAsync(x=>x.Id==request.Id);
            await patternRules.PatternIsNotFound(pattern);

            pattern.IsDeleted = true;
            await unitOfWork.GetWriteRepository<Pattern>().UpdateAsync(pattern);
            if (await unitOfWork.SaveAsync() > 0)
            {
                response.IsSuccess = true;
                response.Message = "Kalıp Başarıyla Silindi";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Kalıp Silinemedi";
            }
            return response;
        }
    }
}
