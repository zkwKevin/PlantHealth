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
         private readonly IDayLogManager _dayLogManager;
    
        public TodoItermController(IMapper mapper, ITodoItemManager todoItemManager, ITargetItemManager targetManager, ITodoLogManager todoLogManager, IDayLogManager dayLogManager)
        {
            _todoItemManager = todoItemManager;
            _todoLogManager = todoLogManager;
            _targetManager = targetManager;
            _dayLogManager = dayLogManager;
            _mapper = mapper;
        }

        //Get a TodoItemlist of a target
        [HttpGet]
        public ActionResult<List<TodoItem>> GetTodoItemList(int targetId){
            var targetItem = _targetManager.GetTargetItemById(targetId);
            if(targetItem == null)
            {
              return NotFound();
            }
            return  _todoItemManager.GetAllDefaultTodoItems(targetItem);
        }


        //Add a todolog for a target with action in selection
        [HttpPost("{todoItemId}")]
        public IActionResult CreateTodoLogWithDefaultSelection(int targetId, int todoItemId)
        {
            var targetItem = _targetManager.GetTargetItemById(targetId);
            var isExist = _todoLogManager.TodoLogIsExist( targetItem, todoItemId);
            if(targetItem == null || isExist)
            {
              return NotFound();
            }
            //Create todoLog
            var IdJustCreated = _todoLogManager.AddTodoLogForTargetItem(targetItem, todoItemId);
            //Create dayLog
            _dayLogManager.CreateFirstDayLog(IdJustCreated); 
            return NoContent();
        }

        //Add a todolog for a target with custom action
        [HttpPost]
        public IActionResult CreateCustomTodoLog(int targetId, TodoItem todoItem)
        {
            var targetItem = _targetManager.GetTargetItemById(targetId);
            if(targetItem == null)
            {
              return NotFound();
            }
            _todoItemManager.CreateTodoItem(todoItem, targetItem);
            var IdJustCreated = _todoLogManager.AddTodoLogForTargetItem(targetItem , todoItem.Id);
            _dayLogManager.CreateFirstDayLog(IdJustCreated);
            return NoContent();
        }

        //Admin add todoIterm
        // [HttpPost]
        // public IActionResult AddTodoIterm (TodoItem todoIterm)
        // {
           
        // }



        //Admin delete todoIterm
        [HttpDelete("{itermId}")]
        public IActionResult DeleteTodoIterm (int itermId)
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

