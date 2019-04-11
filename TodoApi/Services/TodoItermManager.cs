
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public class TodoItemManager : ITodoItemManager
    {
        private readonly TodoContext _context;
        public TodoItemManager(TodoContext context)
        {
            _context = context;
        }

        public TodoItem GetTodoItemById(int id){
            var item = _context.TodoItems.Find(id);
            return item;
        }

        public List<TodoItem> GetAllDefaultTodoItems(TargetItem targetItem)
        {
            return  _context.TodoItems.Where(x => x.IsBuildIn == true && x.Type.Value == targetItem.Type.Value).ToList();  
        }

        public void CreateTodoItem(TodoItem item, TargetItem targetItem)
        {
            item.IsBuildIn = false;
            item.Type = targetItem.Type;
            _context.TodoItems.Add(item);
            _context.SaveChanges(); 
        }

        public void DeleteTodoIterm(TodoItem item)
        {
            _context.TodoItems.Remove(item);
            _context.SaveChanges();
        }
    }
}