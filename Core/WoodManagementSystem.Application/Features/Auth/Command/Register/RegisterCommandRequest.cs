using MediatR;

namespace WoodManagementSystem.Application.Features.Auth.Command.Register
{
    public class RegisterCommandRequest : IRequest<Unit>
    {
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
