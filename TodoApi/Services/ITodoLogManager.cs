using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface ITodoLogManager
    {
        TodoLog CreateTodoLogForBuiltIn(TodoLog todoLog);
        void DeleteTodoLogForTargetItem(TodoItem todoItem, TodoLog todoLog);
        void DeleteAllLogs(List<TodoLog> allLog);
        void UpdateTodoLog(TodoItem todoItem);

    }
}