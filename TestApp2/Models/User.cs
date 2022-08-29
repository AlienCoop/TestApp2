namespace TestApp2.Models
{
    public enum Status
    {
        active,
        offline,
        blocked
    }

    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime? DateOfModification { get; set; }
        public Status? Status { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

    }
}
