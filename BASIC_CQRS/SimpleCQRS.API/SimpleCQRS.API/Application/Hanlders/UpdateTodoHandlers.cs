

using MediatR;
using SimpleCQRS.API.Application.Command;
using SimpleCQRS.API.Context;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace SimpleCQRS.API.Application.Hanlders
{
    public class UpdateTodoHandlers : IRequestHandler<UpdateTodo, int>
    {
        private readonly TodoDbContext _context;
        public UpdateTodoHandlers(TodoDbContext context) => _context = context;
        public async Task<int> Handle(UpdateTodo request, CancellationToken cancellationToken)
        {
            var todo = _context.Todos.Where(a => a.Id == request.Id).FirstOrDefault();

            if (todo == null)
            {
                return default;
            }
            else
            {
                todo.Text = request.Text;
                todo.IsFinihed = request.IsFinihed;
                return await _context.SaveChangesAsync();
            }
        }
    }
}
