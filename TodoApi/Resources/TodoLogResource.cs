using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Models
{
    public class TodoLogResource
    {
        public long Id { get; set;}
        public TodoItem TodoItem { get; set;}
        public long TargetItemId { get; set;}
        public TargetItem TargetItem { get; set;}

    }
}