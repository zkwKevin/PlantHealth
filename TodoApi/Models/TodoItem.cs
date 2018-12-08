namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set;}
        public string Name { get; set;}
        public int Time { get; set;}
        public long TodoLogForeignKey {get; set;}
        public TodoLog TodoLog {get; set;}
    }
}