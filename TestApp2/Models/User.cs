using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace TestApp2.Models
{
    public enum Status
    {
        active,
        offline,
        blocked
    }

    [Table("Users")]
    public class User
    {


        [Key]
        public int UserID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfModification { get; set; }
        public Status? Status { get; set; }


        public virtual ICollection<Task> Tasks { get; set; }
        public partial class AppContext : DbContext
        {
            public DbSet<User> Statuses { get; set; }
        }

    }


}
