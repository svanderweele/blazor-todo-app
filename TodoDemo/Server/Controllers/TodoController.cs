using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoDemo.Server.Services;
using TodoDemo.Shared;

namespace TodoDemo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            this._todoService = todoService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<TodoModel>> Get() => _todoService.Get();


        [HttpGet("{id:length(24)}", Name = "GetTodo")]
        public ActionResult<TodoModel> Get(string id)
        {
            var todo = _todoService.Get(id);
            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        [HttpPost]
        public ActionResult<TodoModel> Create(TodoModel todo)
        {
            _todoService.Create(todo);
            return CreatedAtRoute("GetTodo", new { id = todo.Id.ToString() }, todo);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<TodoModel> Update(string id, TodoModel modelIn)
        {
            var todo = _todoService.Get(id);

            if (todo == null)
            {
                return Json("test");
            }

            _todoService.Update(id, modelIn);

            return Json(new { success = true, message = "Data updated successfully!" });
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var todo = _todoService.Get(id);
            if (todo == null)
            {
                return NotFound();
            }

            _todoService.Remove(id);

            return NoContent();
        }

    }
}