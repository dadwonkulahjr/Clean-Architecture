using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CaWorkshop.Domain.Entities;
using CaWorkshop.Infrastructure.Persistence;
using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using MediatR;
using CaWorkshop.Application.TodoLists.Commands.CreateTodoList;
using CaWorkshop.Application.TodoLists.Commands.UpdateTodoList;
using CaWorkshop.Application.TodoLists.Commands.DeleteTodoList;

namespace aWorkshop.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoListsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoLists([FromServices] IGetTodoListsQuery query)
        {
            return await _mediator.Send(new GetTodoListsQuery());
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
        public async Task<IActionResult> PutTodoList(int id, UpdateTodoListCommand updateTodoListCommand)
        {
            if (id != updateTodoListCommand.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(updateTodoListCommand);
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<int>> PostTodoList(CreateTodoListCommand createTodoListCommand)
        {
            return await _mediator.Send(createTodoListCommand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList(int id)
        {
            await _mediator.Send(new DeleteTodoListCommand() { Id = id });
            return NoContent();
        }
        //private bool TodoListExists(int id)
        //{
           
        //}
    }
}
