using Microsoft.EntityFrameworkCore;
using TestApp2.Interfaces;
using TestApp2.Models;
using Task = TestApp2.Models.Task;
using TaskStatus = TestApp2.Models.TaskStatus;

namespace TestApp2.DAL
{
    public class MainContext : DbContext, IMainDbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.UserID).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.DateOfCreation).HasColumnType("timestamp");
                entity.Property(e => e.DateOfModification).HasColumnType("timestamp");

                entity
                   .HasMany(t => t.Tasks)
                   .WithOne(u => u.TaskWorker)
                   .HasForeignKey(t => t.TaskWorkerID);

            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.TaskID);
                entity.Property(e => e.TaskID).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.CreatedDate).HasColumnType("timestamp");
                entity.Property(e => e.UpdatedDate).HasColumnType("timestamp");

            });

            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User{UserID=1,Name="Bob", Surname="Marley",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
                new User{UserID=2,Name="Elvis", Surname="Presley",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
                new User{UserID=3,Name="James", Surname="Brown",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
                new User{UserID=4,Name="Jackie", Surname="Wilson",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
                new User{UserID=5,Name="Bobby", Surname="Sobaken",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
            });

            modelBuilder.Entity<Task>().HasData(new Task[]
            {
                new Task{TaskID=1, Name="Programming",Description="You need to programme something",CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now, TaskStatus=TaskStatus.not_started, TaskCreaterID=1, TaskWorkerID=2},
                new Task{TaskID=2, Name="Programming",Description ="Do it again", CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,TaskStatus=TaskStatus.working, TaskCreaterID=1,TaskWorkerID=2 },
                new Task{TaskID=3, Name="Bober",Description ="OneTwoThree", CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,TaskStatus=TaskStatus.rejected, TaskCreaterID=1,TaskWorkerID=2 },
                new Task{TaskID=4, Name="PopkaBobra",Description ="FourFiveSix", CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,TaskStatus=TaskStatus.finished, TaskCreaterID=3,TaskWorkerID=4 },
                new Task{TaskID=5, Name="Koteika",Description ="SevenEleven", CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,TaskStatus=TaskStatus.not_started, TaskCreaterID=3,TaskWorkerID=5 },
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}


//dropcreatedatabasealways<>