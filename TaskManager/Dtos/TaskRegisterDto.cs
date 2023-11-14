using TaskManager.Enums;

namespace TaskManager.Dtos
{
    public class TaskRegisterDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
        public Status Status { get; set; }
        public int UserId { get; set; }
        
    }
}
