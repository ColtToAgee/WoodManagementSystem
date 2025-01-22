using MediatR;
using Microsoft.AspNetCore.Identity;
using WoodManagementSystem.Application.Interfaces.UnitOfWorks;
using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.Application.Features.Auth.Command.RefreshPassword
{
    public class RefreshPasswordCommandHandler : IRequestHandler<RefreshPasswordCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<User> userManager;

        public RefreshPasswordCommandHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        public async Task<Unit> Handle(RefreshPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
