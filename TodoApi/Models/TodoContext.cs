using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        //base将调用父类DbContext的构造函数，传入的参数是-类型为TodoConText类的option类
        //DbContext类-一个数据库对象的实例
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        //DbSet类-一个数据库表对象的实例
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<ObjectItem> ObjectItems { get; set; }
    }
}