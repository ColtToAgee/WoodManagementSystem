using MediatR;

namespace WoodManagementSystem.Application.Features.Patterns.Command.CreatePattern
{
    public class CreatePatternCommandRequest : IRequest<CreatePatternCommandResponse>
    {
        public string PatternName { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Cost { get; set; }
    }
}
