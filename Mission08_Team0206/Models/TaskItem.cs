using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0206.Models;

public class TaskItem
{
    [Key]
    public int TaskItemId { get; set; }

    [Required(ErrorMessage = "Task name is required.")]
    [Display(Name = "Task")]
    public string TaskDescription { get; set; } = string.Empty;

    [Display(Name = "Due Date")]
    public DateTime? DueDate { get; set; }

    [Required(ErrorMessage = "Quadrant is required.")]
    [Range(1, 4)]
    public int Quadrant { get; set; }

    [ForeignKey("Category")]
    [Display(Name = "Category")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public bool Completed { get; set; } = false;
}
