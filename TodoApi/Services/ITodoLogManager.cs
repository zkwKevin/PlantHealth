using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface ITodoLogManager
    {
        int AddTodoLogForTargetItem(TargetItem targetItem, int todoItemId);
        void DeleteTodoLogForTargetItem(TodoItem todoItem, TodoLog todoLog);
        List<TodoLog> GetTodoLogForTargetItem(int targetId);
        TodoLog GetATodoLog(int todologId);
        void DeleteAllLogs(List<TodoLog> allLog);
        bool TodoLogIsExist(TargetItem targetItem, int todoItemId);
        void UpdateTodoLog(TodoItem todoItem);
        TodoItem GetTodoItemForTodoLog(TodoLog todoLog);

    }
}