using MediatR;

namespace WoodManagementSystem.Application.Features.Auth.Command.GenerateRefreshPasswordCode
{
    public class RefreshPasswordCodeCommandRequest : IRequest<Unit>
    {
        public string Email { get; set; }
    }
}
