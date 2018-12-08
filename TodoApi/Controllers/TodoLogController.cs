using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
using TodoApi.Service;

namespace TodoApi.Controllers{
    [Route("api/targetItems/{targetId}/actions")]
    [ApiController]
    public class TodoLogController : ControllerBase{
        private readonly ITodoLogManager _todoLogManager;
        private readonly IMapper _mapper;
        private readonly ITargetItemManager  _targetManager;



        public TodoLogController(ITodoLogManager manager, IMapper mapper, ITargetItemManager targetManager)
        {
            _todoLogManager = manager;
            _targetManager = targetManager;
            _mapper = mapper;
        }
        
        //Add a todolog for a target
        [HttpPost]
        public IActionResult CreateTodoLog(long targetId, TodoItem todoItem){
          var targetItem = _targetManager.GetTargetItemById(targetId);
          if(targetItem == null)
          {
              return NotFound();
          }

          _todoLogManager.AddTodoLogForTargetItem(targetItem, todoItem);
                  
          return Ok();
        }

        //Get a TodoLoglist of a target
        [HttpGet(Name = "GetLogList")]
        public ActionResult<List<TodoLog>> GetLogList(long targetId){
                return  _todoLogManager.GetTodoLogForTargetItem(targetId);
        }   

        [HttpDelete("{todologId}")]
        public IActionResult DeleteTodoLog(long todologId)
        {
            var todolog = _todoLogManager.GetATodoLog(todologId);
            if(todolog== null ){
                return NotFound();
            }
            _todoLogManager.DeleteTodoLogForTargetItem(todolog);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteAll(long todologId)
        {
            var todolog = _todoLogManager.GetATodoLog(todologId);
            if(todolog== null ){
                return NotFound();
            }
            _todoLogManager.DeleteTodoLogForTargetItem(todolog);
            return NoContent();
        }
    }
}