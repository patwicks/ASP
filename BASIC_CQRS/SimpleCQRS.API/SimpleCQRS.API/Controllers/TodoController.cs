using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleCQRS.API.Application.Command;
using SimpleCQRS.API.Application.Queries;
using SimpleCQRS.API.Model;

namespace SimpleCQRS.API.Controllers
{
    [ApiController]
    [Route("api/todos")]
    public class TodoController : Controller
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator) => _mediator = mediator;


        [HttpGet]
        [ProducesResponseType(typeof(TodoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTodos()
        {
            var result = await _mediator.Send(new GetAllTodosQuery());
            return result == null ? NotFound() : Ok(result);
        }

        //Get Todo by Id
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(TodoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTodoById(Guid id)
        {
            var result = await _mediator.Send(new GetTodosByIdQuery { Id = id });

            return result == null ? NotFound() : Ok(result);
        }
        //Add todo

        [HttpPost]
        [ProducesResponseType(typeof(TodoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddTodo([FromBody] AddTodo request)
        {
            var result = await _mediator.Send(request);

            return result == null ? NotFound() : Ok(result);
        }

        //Delete Todo
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(TodoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            await _mediator.Send(new DeleteTodo { Id = id });

            return NoContent();
        }


        //Update Todo
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(TodoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTodo(Guid id, UpdateTodo request)
        {
            request.Id = id;

            var result = await _mediator.Send(request);

            return result == null ? NoContent() : Ok(result);
        }

    }
}
