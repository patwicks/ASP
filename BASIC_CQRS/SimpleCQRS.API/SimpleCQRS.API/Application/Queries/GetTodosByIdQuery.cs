using MediatR;
using SimpleCQRS.API.Model;

namespace SimpleCQRS.API.Application.Queries
{
    public class GetTodosByIdQuery : IRequest<TodoModel>
    {
        public Guid Id { get; set; }
    }
}
