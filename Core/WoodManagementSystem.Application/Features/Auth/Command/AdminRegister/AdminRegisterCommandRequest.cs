using MediatR;

namespace WoodManagementSystem.Application.Features.Auth.Command.AdminRegister
{
    public class AdminRegisterCommandRequest : IRequest<Unit>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
