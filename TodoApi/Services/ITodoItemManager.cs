using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface ITodoItemManager
    {
       void CreateTodoItem(TodoItem item, TargetItem targetItem);
       TodoItem GetTodoItemById(int id);
       void DeleteTodoIterm(TodoItem item);

       List<TodoItem> GetAllDefaultTodoItems(TargetItem targetItem);


    }
}