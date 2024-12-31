using MediatR;

namespace WoodManagementSystem.Application.Features.Users.Command.UpdateUser
{
    public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
    }
}
