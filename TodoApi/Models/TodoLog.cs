using System.Collections.Generic;

namespace TodoApi.Models
{
    public class TodoLog
    {
        public int Id { get; set;}
        public int TodoItemId { get; set;}
        public TodoItem TodoItem { get; set;}
        public int TargetItemId { get; set;}
        public TargetItem TargetItem { get; set;}
        public List<DayLog> DayLogs { get; set;}
        
        

    }
}