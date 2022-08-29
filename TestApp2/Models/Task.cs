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

    public class Task
    {
        public int TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public TaskStatus? TaskStatus { get; set; }
        public int TaskCreaterID { get; set; }
        public int TaskWorkerID { get; set; }


        public virtual User TaskCreater { get; set; }
        public virtual User TaskWorker { get; set; }
    }
}
