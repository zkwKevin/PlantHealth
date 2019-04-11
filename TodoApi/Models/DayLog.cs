using System;
using System.Collections.Generic;

namespace TodoApi.Models
{
    public class DayLog
    {
        public int Id { get; set;}
        public DateTime Date { get; set;}
        public bool isComplete { get; set;}
        public int TodoLogId {get; set;}
        public TodoLog TodoLog {get; set;}
    }
}