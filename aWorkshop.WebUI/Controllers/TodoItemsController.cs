using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaWorkshop.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using CaWorkshop.Application.TodoItems.Commands.CreateTodoItem;
using CaWorkshop.Application.TodoItems.Commands.UpdateTodoItem;
using CaWorkshop.Application.TodoItems.Commands.DeleteTodoItem;

namespace aWorkshop.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TodoList>> GetTodoList(int id)
        //{
        //    var todoList = await _context.TodoLists.FindAsync(id);

        //    if (todoList == null)
        //    {
        //        return NotFound();
        //    }

        //    return todoList;
        //}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList(long id, UpdateTodoItemCommand updateTodoItemCommand)
        {
            if (id != updateTodoItemCommand.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(updateTodoItemCommand);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<long>> PostTodoItem(CreateTodoItemCommand createTodoItemCommand)
        {
           return await _mediator.Send(createTodoItemCommand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList(long id)
        {
            await _mediator.Send(new DeleteTodoItemCommand() { Id = id });
            return NoContent();
        }
        ////private bool TodoItemExists(long id)
        //{
        //    return _context.TodoItems.Any(e => e.Id == id);
        //}
    }
}
