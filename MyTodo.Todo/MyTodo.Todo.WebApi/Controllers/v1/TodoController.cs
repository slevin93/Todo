using Microsoft.AspNetCore.Mvc;
using MyTodo.Todo.Application.Features.TodoItems.Commands.CreateTodoItems;
using MyTodo.Todo.Application.Features.TodoItems.Commands.DeleteTodoItemById;
using MyTodo.Todo.Application.Features.TodoItems.Commands.UpdateTodoItem;
using MyTodo.Todo.Application.Features.TodoItems.Queries.GetAllTodoItems;
using System.Threading.Tasks;

namespace MyTodo.Todo.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TodoController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllTodoItemsParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllTodoItemsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateTodoItemCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateTodoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Put(DeleteTodoItemByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
