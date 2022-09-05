using MediatR;
using SimpleCQRS.API.Application.Command;
using SimpleCQRS.API.Context;

namespace SimpleCQRS.API.Application.Hanlders
{
    public class DeleteTodoHandlers : IRequestHandler<DeleteTodo, Unit>
    {
        private readonly TodoDbContext _context;

        public DeleteTodoHandlers(TodoDbContext context)=> _context = context;
        
        public async Task<Unit> Handle(DeleteTodo request, CancellationToken cancellationToken)
        {
            var todo = await _context.Todos.FindAsync(request.Id);
            if (todo == null) return Unit.Value;

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
