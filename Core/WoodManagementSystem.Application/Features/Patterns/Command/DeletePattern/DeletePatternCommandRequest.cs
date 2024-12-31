using MediatR;

namespace WoodManagementSystem.Application.Features.Patterns.Command.DeletePattern
{
    public class DeletePatternCommandRequest : IRequest<DeletePatternCommandResposne>
    {
        public int Id { get; set; }
    }
}
