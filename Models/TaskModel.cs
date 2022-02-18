using System.ComponentModel.DataAnnotations;

namespace webapi1.Models
{
    public class TaskModel
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        [Required]
        public string Title {get; set;}
        [Required]
        public bool IsCompleted {get; set;}
    }
}