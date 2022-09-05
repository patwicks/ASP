using MediatR;
using SimpleCQRS.API.Context;
using SimpleCQRS.API.Model;

namespace SimpleCQRS.API.Application.Command
{
    public class AddTodo : IRequest<TodoModel>
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = null!;
        public bool IsFinihed { get; set; }
    }
}
