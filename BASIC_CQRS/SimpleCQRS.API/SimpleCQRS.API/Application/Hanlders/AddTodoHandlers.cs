using MediatR;
using SimpleCQRS.API.Application.Command;
using SimpleCQRS.API.Context;
using SimpleCQRS.API.Model;

namespace SimpleCQRS.API.Application.Hanlders
{
    public class AddTodoHandlers : IRequestHandler<AddTodo, TodoModel>
    {
        private readonly TodoDbContext _context;

        public AddTodoHandlers(TodoDbContext context) => _context = context;

        public async Task<TodoModel> Handle(AddTodo request, CancellationToken cancellationToken)
        {
            var entity = new TodoModel()
            {
                Id = Guid.NewGuid(),
                Text = request.Text,
                IsFinihed = request.IsFinihed
            };

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
