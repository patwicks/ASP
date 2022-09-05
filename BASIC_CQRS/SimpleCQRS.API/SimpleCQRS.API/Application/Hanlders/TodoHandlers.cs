using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCQRS.API.Application.Queries;
using SimpleCQRS.API.Context;
using SimpleCQRS.API.Model;

namespace SimpleCQRS.API.Application.Hanlders
{
    public class TodoHandlers : IRequestHandler<GetAllTodosQuery, List<TodoModel>>
    {
        private readonly TodoDbContext _context;

        public TodoHandlers(TodoDbContext context) => _context = context;
        
        public async Task<List<TodoModel>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Todos.ToListAsync();

            return result;
            
        }
    }
}
