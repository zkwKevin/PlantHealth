using System.Collections.Generic;

namespace TodoApi.Models
{
    public class TodoLog
    {
        public long Id { get; set;}
        public long TodoItemId { get; set;}
        public TodoItem TodoItem { get; set;}
       
        public long TargetItemId { get; set;}
        public TargetItem TargetItem { get; set;}
        public List<DayLog> DayLogs { get; set;}
        
        

    }
}