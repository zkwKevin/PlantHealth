using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Models
{
    public class TodoItemResources
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public int TimesForMode { get; set;}
        public int Time { get; set;}
        
        public enum ModeType
        {
            Hour = 0,
            Day = 1,
            Week = 2,
            Month = 3
        }
        public ModeType Mode { get; set;}
        public string ModeValue { get; set;}
        public virtual List<TodoLog> Logs { get; set;}

        public bool IsBuildIn { get; set;}

        public enum Kind 
        { 
            Animal = 0, 
            Plant = 1
        }
        public Kind Type { get; set;}
    }
}