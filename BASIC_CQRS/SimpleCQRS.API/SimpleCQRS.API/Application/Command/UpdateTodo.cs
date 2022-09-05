using MediatR;

namespace SimpleCQRS.API.Application.Command
{
    public class UpdateTodo : IRequest<int>
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = null!;
        public bool IsFinihed { get; set; }
    }
}
