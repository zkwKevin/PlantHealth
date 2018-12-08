

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


        public void AddTodoLogForTargetItem(TargetItem targetItem, TodoItem todoItem)
        {
     
            _context.TodoLogs.Add(new TodoLog {TargetItemId = targetItem.Id, TodoItem = new TodoItem{ Name = todoItem.Name, Time = todoItem.Time}});
            
            _context.SaveChanges();
        }
        public void DeleteTodoLogForTargetItem(TodoLog todoLog)
        {
            _context.TodoLogs.Remove(todoLog);
            _context.SaveChanges();  
        }

        public void DeleteAllLogs(List<TodoLog> allLogs)
        {
            _context.TodoLogs.RemoveRange(allLogs);
            _context.SaveChanges();  
        }
    }
}