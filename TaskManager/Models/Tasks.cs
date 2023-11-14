using TaskManager.Enums;

namespace TaskManager.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
    }
}
