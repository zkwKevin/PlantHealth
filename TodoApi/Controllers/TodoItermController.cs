using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
using TodoApi.Service;

namespace TodoApi.Controllers{
    [Route("api/targetItems/{targetId}/actions")]
    [ApiController]
    public class TodoItermController : ControllerBase{
        private readonly IMapper _mapper;
        private readonly ITodoItemManager  _todoItemManager;
        private readonly ITargetItemManager _targetManager;
         private readonly ITodoLogManager _todoLogManager;
    
        public TodoItermController(IMapper mapper, ITodoItemManager todoItemManager, ITargetItemManager targetManager, ITodoLogManager todoLogManager)
        {
            _todoItemManager = todoItemManager;
            _todoLogManager = todoLogManager;
            _targetManager = targetManager;
            _mapper = mapper;
        }

        //Get a TodoItemlist of a target
        [HttpGet]
        public ActionResult<List<TodoItem>> GetTodoItemList(long targetId){
            var targetItem = _targetManager.GetTargetItemById(targetId);
            if(targetItem == null)
            {
              return NotFound();
            }
            return  _todoItemManager.GetAllDefaultTodoItems(targetItem);
        }


        //Add a todolog for a target with action in selection
        [HttpPost("{todoItemId}")]
        public IActionResult CreateTodoLogWithDefaultSelection(long targetId, long todoItemId)
        {
            var targetItem = _targetManager.GetTargetItemById(targetId);
            var isExist = _todoLogManager.TodoLogIsExist( targetItem, todoItemId);
            if(targetItem == null || isExist)
            {
              return NotFound();
            }
            
            _todoLogManager.AddTodoLogForTargetItem(targetItem, todoItemId);
            
            return NoContent();
        }

        //Add a todolog for a target with custom action
        [HttpPost]
        public IActionResult CreateCustomTodoLog(long targetId, TodoItem todoItem)
        {
            var targetItem = _targetManager.GetTargetItemById(targetId);
            if(targetItem == null)
            {
              return NotFound();
            }
              _todoItemManager.CreateTodoItem(todoItem, targetItem);
              _todoLogManager.AddTodoLogForTargetItem(targetItem , todoItem.Id);
            
            return NoContent();
        }

        //Admin add todoIterm
        // [HttpPost]
        // public IActionResult AddTodoIterm (TodoItem todoIterm)
        // {
           
        // }



        //Admin delete todoIterm
        [HttpDelete("{itermId}")]
        public IActionResult DeleteTodoIterm (long itermId)
        {
            var iterm = _todoItemManager.GetTodoItemById(itermId);

            if( iterm == null)
            {
                return NotFound();
            }

            _todoItemManager.DeleteTodoIterm(iterm);
            return NoContent();
        }
    }
        
}

