using System;
using System.Collections.Generic;
using TestApp2.Models;
using Task = TestApp2.Models.Task;
using TaskStatus = TestApp2.Models.TaskStatus;

namespace TestApp2.DAL
{
    public static class DbInitializer
    {
        //protected override void Seed(AppContext context)
        //{
        //    var users = new List<User>
        //    {
        //        new User{UserID=1,Name="Bob", Surname="Marley",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
        //        new User{UserID=2,Name="Elvis", Surname="Presley",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
        //        new User{UserID=3,Name="James", Surname="Brown",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
        //        new User{UserID=4,Name="Jackie", Surname="Wilson",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
        //        new User{UserID=5,Name="Bob", Surname="Marley",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
        //    };

        //    users.ForEach(s => context.Users.Add(s));
        //    context.SaveChanges();

        //    var tasks = new List<Task>
        //    {
        //        new Task{TaskID=1, Name="Programming",Description="You need to programme something",CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now, TaskStatus=TaskStatus.not_started, TaskCreaterID=1, TaskWorkerID=2},
        //        new Task{TaskID=2, Name="Programming",Description ="Do it again", CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,TaskStatus=TaskStatus.working, TaskCreaterID=1,TaskWorkerID=2 },
        //        new Task{TaskID=3, Name="Bober",Description ="OneTwoThree", CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,TaskStatus=TaskStatus.rejected, TaskCreaterID=1,TaskWorkerID=2 },
        //        new Task{TaskID=4, Name="PopkaBobra",Description ="FourFiveSix", CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,TaskStatus=TaskStatus.finished, TaskCreaterID=3,TaskWorkerID=4 },
        //        new Task{TaskID=5, Name="Koteika",Description ="SevenEleven", CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,TaskStatus=TaskStatus.not_started, TaskCreaterID=3,TaskWorkerID=5 },
        //    };

        //    tasks.ForEach(s => context.Tasks.Add(s));
        //    context.SaveChanges();
        //}

        public static void Initialize(MainContext context)
        {
            context.Database.EnsureCreated();
            var users = new List<User>
                {
                    new User{UserID=1,Name="Bob", Surname="Marley",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
                    new User{UserID=2,Name="Elvis", Surname="Presley",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
                    new User{UserID=3,Name="James", Surname="Brown",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
                    new User{UserID=4,Name="Jackie", Surname="Wilson",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
                    new User{UserID=5,Name="Bob", Surname="Marley",DateOfCreation=DateTime.Now, DateOfModification=DateTime.Now, Status=Status.active},
                };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var tasks = new List<Task>
                {
                    new Task{TaskID=1, Name="Programming",Description="You need to programme something",CreatedDate=DateTime.Now, UpdatedDate=DateTime.Now, TaskStatus=TaskStatus.not_started, TaskCreaterID=1, TaskWorkerID=2},
                    new Task{TaskID=2, Name="Programming",Description ="Do it again", CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,TaskStatus=TaskStatus.working, TaskCreaterID=1,TaskWorkerID=2 },
                    new Task{TaskID=3, Name="Bober",Description ="OneTwoThree", CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,TaskStatus=TaskStatus.rejected, TaskCreaterID=1,TaskWorkerID=2 },
                    new Task{TaskID=4, Name="PopkaBobra",Description ="FourFiveSix", CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,TaskStatus=TaskStatus.finished, TaskCreaterID=3,TaskWorkerID=4 },
                    new Task{TaskID=5, Name="Koteika",Description ="SevenEleven", CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,TaskStatus=TaskStatus.not_started, TaskCreaterID=3,TaskWorkerID=5 },
                };

            tasks.ForEach(s => context.Tasks.Add(s));
            context.SaveChanges();
        }
    }
}