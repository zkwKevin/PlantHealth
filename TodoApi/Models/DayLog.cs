using System;
using System.Collections.Generic;

namespace TodoApi.Models
{
    public class DayLog
    {
        public long Id { get; set;}
        public DateTime Date { get; set;}
        public bool isComplete { get; set;}
        public long TodoLogId {get; set;}
        public TodoLog TodoLog {get; set;}
    }
}