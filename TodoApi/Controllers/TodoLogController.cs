using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
using TodoApi.Service;

namespace TodoApi.Controllers{
    [Route("api/targetItems/{targetId}")]
    [ApiController]
    public class TodoLogController : ControllerBase{
        private readonly ITodoLogManager _todoLogManager;
        private readonly IMapper _mapper;
        private readonly ITargetItemManager  _targetManager;
        private readonly ITodoItemManager  _todoItemManager;
        private readonly IDayLogManager _dayLogManager;



        public TodoLogController(ITodoLogManager manager, IMapper mapper, ITargetItemManager targetManager, ITodoItemManager todoItemManager, IDayLogManager dayLogManager)
        {
            _todoLogManager = manager;
            _targetManager = targetManager;
            _todoItemManager = todoItemManager;
            _dayLogManager = dayLogManager;
            _mapper = mapper;
        }

        //Update a TodoLog
        [HttpPut("logs/{todologId}")]

        public IActionResult UpdateTodoLog(long targetId, long todologId, TodoItem todoItem)
        {
            var targetItem = _targetManager.GetTargetItemById(targetId);
            if(targetItem == null)
            {
              return NotFound();
            }
            var todoLog = _todoLogManager.GetATodoLog(todologId); 
            if(todoLog == null)
            {
              return NotFound();
            }
            todoItem.Id = todoLog.TodoItemId;
            _todoLogManager.UpdateTodoLog(todoItem);
            _dayLogManager.CreateFirstDayLog(todologId);
            //change the mode
            //********* */
            return NoContent();
        }
        

        

        //Get a TodoLoglist of a target
        [HttpGet("logs", Name = "GetLogList")]
        public ActionResult<List<TodoLog>> GetLogList(long targetId)
        {
                return  _todoLogManager.GetTodoLogForTargetItem(targetId);
        }

        //Delete a TodoLog
        [HttpDelete("{todologId}")]
        public IActionResult DeleteTodoLog(long todologId)
        {
            var todolog = _todoLogManager.GetATodoLog(todologId);
            if(todolog== null ){
                return NotFound();
            }
            var todoItem = _todoItemManager.GetTodoItemById(todolog.TodoItemId);
            _todoLogManager.DeleteTodoLogForTargetItem(todoItem, todolog);
            
            return NoContent();
        }
        //Delete all TodoLogs
        [HttpDelete]
        public IActionResult DeleteAll(long targetId)
        {
            var todologs = _todoLogManager.GetTodoLogForTargetItem(targetId);
            if(todologs== null ){
                return NotFound();
            }
            _todoLogManager.DeleteAllLogs(todologs);
            return NoContent();
        }
    }
}