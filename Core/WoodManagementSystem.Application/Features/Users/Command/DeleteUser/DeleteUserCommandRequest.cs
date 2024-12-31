using MediatR;

namespace WoodManagementSystem.Application.Features.Users.Command.DeleteUser
{
    public class DeleteUserCommandRequest : IRequest<DeleteUserCommandResponse>
    {
        public int Id { get; set; }
    }
}
