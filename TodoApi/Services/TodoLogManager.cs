

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using WebApi.Helpers;

namespace TodoApi.Service
{
    public class TodoLogManager : ITodoLogManager
    {
        private readonly TodoContext _context;
        public TodoLogManager(TodoContext context)
        {
            _context = context;
        }

        public TodoLog CreateTodoLogForBuiltIn(TodoLog todoLog)
        {
            if(_context.TodoLogs.Any(x => x.TargetItemId == todoLog.TargetItemId && x.TodoItemId == todoLog.TodoItemId))
                throw new AppException("This action is already included");
            _context.TodoLogs.Add(todoLog);
            _context.SaveChanges(); 
            return todoLog;
             
        }


        public void UpdateTodoLog(TodoItem todoItem)
        {
            if(todoItem.IsBuildIn == false)
            {
                _context.TodoItems.Update(todoItem);
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