using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase{
        private readonly TodoContext _context;

        public TodoController(TodoContext context){
            _context = context;

            // if(_context.TodoItems.Count() == 0){
            //     _context.TodoItems.Add(new TodoItem { Name = "Feed"});
            //     _context.SaveChanges();
            // }
        }

        [HttpGet("{objectid}", Name = "GetTodoList")]
        public ActionResult<List<TodoItem>> GetAll(long id){
            var thing =  _context.ObjectItems.Find(id);
            if(thing == null ){
                return NotFound();
            }
            return _context.ObjectItem;
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<TodoItem> GetById(long id){
            var item = _context.TodoItems.Find(id);
            if(item == null ){
                return NotFound();
            }
            return item;
        }

        //Create todoitem
        [HttpPost]
        public IActionResult Create(TodoItem item){
            _context.TodoItems.Add(item);
            _context.SaveChanges();
            return CreatedAtRoute("GetTodo", new { id = item.Id}, item );
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, TodoItem item){
            var olditem = _context.TodoItems.Find(id);
            if(olditem == null ){
                return NotFound();
            }
            olditem.IsComplete = item.IsComplete;
            olditem.Name = item.Name;

            _context.TodoItems.Update(olditem);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id){
            var item = _context.TodoItems.Find(id);
            if(item == null ){
                return NotFound();
            }
            _context.TodoItems.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }

    }
}