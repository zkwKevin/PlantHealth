using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface ITodoLogManager
    {
        long AddTodoLogForTargetItem(TargetItem targetItem, long todoItemId);
        void DeleteTodoLogForTargetItem(TodoItem todoItem, TodoLog todoLog);
        List<TodoLog> GetTodoLogForTargetItem(long targetId);
        TodoLog GetATodoLog(long todologId);
        void DeleteAllLogs(List<TodoLog> allLog);
        bool TodoLogIsExist(TargetItem targetItem, long todoItemId);
        void UpdateTodoLog(TodoLog todoLog);

    }
}