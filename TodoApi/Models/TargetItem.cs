using System.Collections.Generic;

namespace TodoApi.Models
{
    public class TargetItem
    {
        public long Id { get; set;}
        public enum Kind 
        { 
            Animal = 0, 
            Plant = 1
        }
        public Kind Type { get; set;}
        public string Name { get; set;}
        public int HealthState { get; set;}
        public List<TodoLog> Logs{ get; set;}
    }
}