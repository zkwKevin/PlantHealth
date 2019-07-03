
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

        public List<TodoItem> GetInbuiltTodoItems(int targetId)
        {
            TargetItem item = _context.TargetItems.Find(targetId);
            return  _context.TodoItems.Where(x => x.IsBuildIn == true && x.Type.Value == item.Type.Value).ToList();  
        }

        public TodoItem CreateTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            _context.SaveChanges(); 
            return todoItem;
        }


        public TodoItem GetTodoItemById(int id){
            var item = _context.TodoItems.Find(id);
            return item;
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