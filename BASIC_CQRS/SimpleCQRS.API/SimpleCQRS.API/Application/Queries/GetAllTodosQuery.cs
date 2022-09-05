using MediatR;
using SimpleCQRS.API.Model;

namespace SimpleCQRS.API.Application.Queries
{
    public class GetAllTodosQuery : IRequest<List<TodoModel>>{}
}
