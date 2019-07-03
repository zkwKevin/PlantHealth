using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
using TodoApi.Service;
using WebApi.Helpers;

namespace TodoApi.Controllers{
    [Route("api/actions")]
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

         //Get a list of all inbuilt todoItems
        [HttpGet("{targetId}")]
        public ActionResult<List<TodoItem>> GetInbuiltTodoItems([FromRoute] int targetId){
            
                var todoItems = _todoItemManager.GetInbuiltTodoItems(targetId);
                var todoItemResources = _mapper.Map<List<TodoItem>>(todoItems);
                return Ok(todoItemResources);
            
        }


        [HttpPost]
        public IActionResult CreateTodoItem([FromBody] TodoItem todoItem){
            try
            {
                _todoItemManager.CreateTodoItem(todoItem);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
        // //Add a todolog for a target with action in selection
        // [HttpPost]
        // public IActionResult CreateTodoLogWithDefaultSelection(int targetId, int todoItemId)
        // {
        //     var targetItem = _targetManager.GetTargetItemById(targetId);
        //     var isExist = _todoLogManager.TodoLogIsExist( targetItem, todoItemId);
        //     if(targetItem == null || isExist)
        //     {
        //       return NotFound();
        //     }
        //     //Create todoLog
        //     var IdJustCreated = _todoLogManager.AddTodoLogForTargetItem(targetItem, todoItemId);
        //     //Create dayLog
        //     _dayLogManager.CreateFirstDayLog(IdJustCreated); 
        //     return NoContent();
        // }

        // //Add a todolog for a target with custom action
        // [HttpPost]
        // public IActionResult CreateCustomTodoLog(int targetId, TodoItem todoItem)
        // {
        //     var targetItem = _targetManager.GetTargetItemById(targetId);
        //     if(targetItem == null)
        //     {
        //       return NotFound();
        //     }
        //     _todoItemManager.CreateTodoItem(todoItem, targetItem);
        //     var IdJustCreated = _todoLogManager.AddTodoLogForTargetItem(targetItem , todoItem.Id);
        //     _dayLogManager.CreateFirstDayLog(IdJustCreated);
        //     return NoContent();
        // }

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

