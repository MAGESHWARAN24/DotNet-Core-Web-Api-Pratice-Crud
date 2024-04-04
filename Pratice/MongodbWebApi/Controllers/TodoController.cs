using Microsoft.AspNetCore.Mvc;
using MongodbWebApi.Dto;
using MongodbWebApi.Models;
using MongodbWebApi.Services;

namespace MongodbWebApi.Controllers
{
    [Route("Todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _TodoService;

        public TodoController(TodoService todoService) => _TodoService = todoService;

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var Todos = await _TodoService.GetAllTodo();
            return Ok(Todos);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTodo([FromBody] TodoCreateDTO todo)
        {
            var newTodo = new Todo();
            newTodo.TaskTittle = todo.TaskTittle;
            newTodo.Description = todo.Description;
            await _TodoService.CreateTodo(newTodo);
            return Ok();
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetTodoId(string id)
        {
            var Todo = await _TodoService.GetTodoId(id);
            return Ok(Todo);
        }
        [HttpPut("id")]
        public async Task<ActionResult> UpdateTodoStatus(string id, [FromBody] TodoUpdateDTO todo)
        {
            await _TodoService.UpdateTodo(id, todo.Status);
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteTodo(string id)
        {
            await _TodoService.DeleteTodo(id);
            return NoContent();
        }
    }
}
