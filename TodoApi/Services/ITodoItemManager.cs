using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface ITodoItemManager
    {
       void CreateTodoItem(TodoItem item, TargetItem targetItem);
       TodoItem CreateTodoItem(TodoItem todoItem);
       TodoItem GetTodoItemById(int id);
       void DeleteTodoIterm(TodoItem item);

       List<TodoItem> GetInbuiltTodoItems(int targetId);


    }
}