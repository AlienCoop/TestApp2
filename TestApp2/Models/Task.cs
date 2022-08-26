using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp2.Models
{
    public enum TaskStatus
    {
        not_started,
        working,
        finished,
        cancelled,
        rejected
    }
    [Table("Tasks")]
    public class Task
    {
        [Key]
        public int TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public TaskStatus? TaskStatus { get; set; }
        public int TaskCreaterID { get; set; }
        public int TaskWorkerID { get; set; }


        public virtual User User { get; set; }

        public partial class AppContext : DbContext
        {
            public DbSet<User> Statuses { get; set; }
        }
    }
}
