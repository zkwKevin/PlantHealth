using System;

namespace TodoApi.Models
{
    public class DayLog
    {
        public long Id { get; set;}
        public string TodoItermId { get; set;}
        public DateTime Date { get; set;}
        public bool isComplete { get; set;}

    }
}