using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD.API.Data;
using SimpleCRUD.API.Models;


namespace SimpleCRUD.API.Controllers
{ 
    [Route("todos")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly TodoDbContext context;

        public TodoController(TodoDbContext context)
        {
            this.context = context;
        }

        //Fetch all Todos

        [HttpGet]
        [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTodos()
        {
            var result = await context.Todos.ToListAsync();

            return result == null ? NotFound() : Ok(result);
        }
        //Find Todo by ID
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTodoById([FromRoute] Guid id)
        {
            var result = await context.Todos.FindAsync(id);

            return result == null ? NotFound() : Ok(result);
        }

        //Delete todo
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTodo([FromRoute] Guid id)
        {
            var result = await context.Todos.FindAsync(id);

            if(result != null)
            {
                context.Remove(result);

                await context.SaveChangesAsync();

                return Ok("Todo Deleted");
            }

            return NotFound();
        }

        //Create a todo
        [HttpPost]
        [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateTodo(Todo request)
       
        {

            var nTodo = new Todo()
            {
                Id = request.Id,
                Text = request.Text,
                IsFinihed = request.IsFinihed

            };

            await context.Todos.AddAsync(nTodo);
            await context.SaveChangesAsync();

            return Ok(nTodo);
        }

        //update todo

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTodo([FromRoute] Guid id, Todo request)
        {
            var result = await context.Todos.FindAsync(id);

            if(result != null)
            {
                result.Text = request.Text;
                result.IsFinihed = request.IsFinihed;
            await context.SaveChangesAsync();

            return Ok("Todo Updated");

            }

        return NotFound();
        }

      
    }
}
