using MediatR;

namespace SimpleCQRS.API.Application.Command
{
    public class DeleteTodo : IRequest
    {
        public Guid Id { get; set; }
    }
}
