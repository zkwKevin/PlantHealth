using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Resources
{
    public class TargetItemResource
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
        public int UserId {get; set;}
    }
}