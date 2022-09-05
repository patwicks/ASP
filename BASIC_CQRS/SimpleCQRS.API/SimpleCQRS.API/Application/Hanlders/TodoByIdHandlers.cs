using MediatR;
using SimpleCQRS.API.Application.Queries;
using SimpleCQRS.API.Context;
using SimpleCQRS.API.Model;

namespace SimpleCQRS.API.Application.Hanlders
{
    public class TodoByIdHandlers : IRequestHandler<GetTodosByIdQuery, TodoModel>
    {
        private readonly TodoDbContext _context;

        public TodoByIdHandlers(TodoDbContext context) => _context = context;
    

        public async Task<TodoModel> Handle(GetTodosByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Todos.FindAsync(request.Id);

            return result;
        }
    }
}
