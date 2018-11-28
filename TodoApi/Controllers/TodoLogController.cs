using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Controllers{
    [Route("api/target")]
    [ApiController]
    public class TodoLogController : ControllerBase{
        private readonly TodoContext _context;

        public TodoLogController(TodoContext context){
            _context = context;
        }
        
        //Add a todolog for a target
        // [HttpPost("{id}")]
        // public IActionResult Create(long id, TodoLog log, TodoItem item){
        //     var act = _context.TodoItems.Find()
        //     _context.TodoLogs.Add(log);
        //     _context.TodoItems.Add(item);
        //     _context.SaveChanges();
        //     return CreatedAtRoute("GetLogList", new { id = log.Id}, log );
        // }

        //Get a TodoLoglist of a target
        [HttpGet("{id}/log", Name = "GetLogList")]
        public ActionResult<List<TodoLog>> GetAll(long id){
            var item =  _context.TargetItems.Find(id);
            if(item == null ){
                return NotFound();
            }
            var logs = _context.TodoLogs.Where(e => e.Id == id);
            item.Logs = logs.ToList();       
            return item.Logs;
        }   
    }
}