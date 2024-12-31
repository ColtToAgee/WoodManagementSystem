using MediatR;

namespace WoodManagementSystem.Application.Features.Patterns.Command.UpdatePattern
{
    public class UpdatePatternCommandRequest : IRequest<UpdatePatternCommandResponse>
    {
        public int Id { get; set; }
        public string PatternName { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Cost { get; set; }
    }
}
