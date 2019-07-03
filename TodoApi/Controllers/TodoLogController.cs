using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
using TodoApi.Service;
using WebApi.Helpers;

namespace TodoApi.Controllers{
    [Route("api/todolog")]
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

        //Create todoLog and bind inbuilt todoItems to it

        [HttpPost]
        public IActionResult CreateTodolog([FromBody] TodoLog todoLog){
            try
            {
                _todoLogManager.CreateTodoLogForBuiltIn(todoLog);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        // //Delete a TodoLog
        // [HttpDelete("{todologId}")]
        // public IActionResult DeleteTodoLog(int todologId)
        // {
        //     var todolog = _todoLogManager.GetATodoLog(todologId);
        //     if(todolog== null ){
        //         return NotFound();
        //     }
        //     var todoItem = _todoItemManager.GetTodoItemById(todolog.TodoItemId);
        //     _todoLogManager.DeleteTodoLogForTargetItem(todoItem, todolog);
            
        //     return NoContent();
        // }
        // //Delete all TodoLogs
        // [HttpDelete]
        // public IActionResult DeleteAll(int targetId)
        // {
        //     var todologs = _todoLogManager.GetTodoLogForTargetItem(targetId);
        //     if(todologs== null ){
        //         return NotFound();
        //     }
        //     _todoLogManager.DeleteAllLogs(todologs);
        //     return NoContent();
        // }
    }
}