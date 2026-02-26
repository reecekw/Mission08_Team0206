using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0206.Models;

// Model representing a task in the Eisenhower Matrix (4 Quadrants of Time Management)
// Each task belongs to one of four quadrants based on importance and urgency
public class TaskItem
{
    // Primary key for the TaskItem table
    [Key]
    public int TaskItemId { get; set; }

    // The task description text - required field
    [Required(ErrorMessage = "Task name is required.")]
    [Display(Name = "Task")]
    public string TaskDescription { get; set; } = string.Empty;

    // Optional due date for the task
    [Display(Name = "Due Date")]
    public DateTime? DueDate { get; set; }

    // Quadrant number (1-4) based on the Eisenhower Matrix - required field
    // 1 = Important/Urgent, 2 = Important/Not Urgent
    // 3 = Not Important/Urgent, 4 = Not Important/Not Urgent
    [Required(ErrorMessage = "Quadrant is required.")]
    [Range(1, 4)]
    public int Quadrant { get; set; }

    // Foreign key linking to the Category table (optional)
    [ForeignKey("Category")]
    [Display(Name = "Category")]
    public int? CategoryId { get; set; }

    // Navigation property for the related Category
    public Category? Category { get; set; }

    // Tracks whether the task has been completed (defaults to false)
    public bool Completed { get; set; } = false;
}
