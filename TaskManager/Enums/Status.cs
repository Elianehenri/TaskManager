using System.ComponentModel.DataAnnotations;

namespace TaskManager.Enums
{
    public enum Status
    {
        [Display(Name = "To Do")]
        Todo = 1,
        [Display(Name = "In Progress")]
        InProgress = 2,
        [Display(Name = "Done")]
        Done = 3
    }
}
