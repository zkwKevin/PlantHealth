using System.Collections.Generic;

namespace TodoApi.Models
{
    public class ObjectItem
    {
        public long Id { get; set;}
        public enum Type { Animal, Plant};
        public string Name { get; set;}
        public int HealthState { get; set;}
        public List<TodoItem> activity { get; set;}
    }
}