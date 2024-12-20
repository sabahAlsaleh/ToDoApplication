using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
