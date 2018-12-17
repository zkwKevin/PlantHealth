

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public class TodoLogManager : ITodoLogManager
    {
        private readonly TodoContext _context;
        public TodoLogManager(TodoContext context)
        {
            _context = context;
        }

        public List<TodoLog> GetTodoLogForTargetItem(long targetId)
        {
            return _context.TodoLogs.Where(x => x.TargetItemId == targetId).ToList();
        }

        public TodoLog GetATodoLog(long todologId)
        {
            return _context.TodoLogs.Find(todologId);
        }


        public void AddTodoLogForTargetItem(TargetItem targetItem, long todoItemId)
        {
            var isExist = _context.TodoLogs.Any(s => s.TargetItemId == targetItem.Id && s.TodoItemId == todoItemId);
            
            if(!isExist)
            {
                _context.TodoLogs.Add(new TodoLog {TargetItemId = targetItem.Id, TodoItemId = todoItemId});
                _context.SaveChanges();
            }   
        }
        

        public void DeleteTodoLogForTargetItem(TodoItem todoItem, TodoLog todoLog)
        {
            if(todoItem.IsBuildIn == false)
            {
                _context.TodoItems.Remove(todoItem);
            } 
            _context.TodoLogs.Remove(todoLog);
            _context.SaveChanges();  
        }

        public void DeleteAllLogs(List<TodoLog> allLogs)
        {
            foreach (TodoLog log in allLogs){
                var todoItem = _context.TodoItems.Find(log.TodoItemId);
                if(todoItem.IsBuildIn == false)
                {
                    _context.TodoItems.Remove(todoItem);
                } 
                _context.TodoLogs.Remove(log);
            }
            _context.SaveChanges();  
        }
    }
}