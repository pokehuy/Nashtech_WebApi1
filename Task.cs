using System.ComponentModel.DataAnnotations;

namespace webapi1
{
    public class Task
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        [Required]
        public string Title {get; set;}
        [Required]
        public bool Completed {get; set;}
    }
}