using Microsoft.EntityFrameworkCore;
using TestApp2.Models;
using Task = TestApp2.Models.Task;

namespace TestApp2.DAL
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.UserID).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Models.Task>(entity =>
            {
                entity.HasKey(e => e.TaskID);
                entity.Property(e => e.TaskID).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(100);
            });

        }
    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using TestApp.Models;

//namespace TestApp.Data
//{
//    public class TestAppContext : DbContext
//    {
//        public TestAppContext(DbContextOptions<TestAppContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<TestApp.Models.User> User { get; set; } = default!;
//    }
//}