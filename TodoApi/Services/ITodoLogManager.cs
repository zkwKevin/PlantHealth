using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface ITodoLogManager
    {
        void AddTodoLogForTargetItem(TargetItem targetItem, long todoItemId);
        void DeleteTodoLogForTargetItem(TodoItem todoItem, TodoLog todoLog);
        List<TodoLog> GetTodoLogForTargetItem(long targetId);
        TodoLog GetATodoLog(long todologId);
        void DeleteAllLogs(List<TodoLog> allLog);

    }
}