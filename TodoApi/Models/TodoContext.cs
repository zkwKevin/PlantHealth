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
        public DbSet<TargetItem> TargetItems { get; set; }
        public DbSet<TodoLog> TodoLogs { get; set; }
        // public DbSet<DayLog> DayLogs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<TodoLog>()
                        .HasOne(p => p.TargetItem)
                        .WithMany(b => b.Logs)
                        .HasForeignKey(p => p.TargetItemId)
                        .IsRequired();

             modelBuilder.Entity<TodoLog>()
                        .HasOne(p => p.TodoItem)
                        .WithOne(b => b.TodoLog)
                        .HasForeignKey<TodoItem>(p => p.TodoLogForeignKey)
                        .IsRequired();

            modelBuilder.Entity<DayLog>()
                        .HasOne(p => p.TodoLog)
                        .WithMany(b => b.DayLogs)
                        .HasForeignKey(p => p.TodoLogId)
                        .IsRequired();
        }
    }
}