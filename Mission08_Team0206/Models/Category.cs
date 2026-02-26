using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0206.Models;

// Model representing a task category (Home, School, Work, Church)
// Stored in a separate table and used to populate the category dropdown
public class Category
{
    // Primary key for the Category table
    [Key]
    public int CategoryId { get; set; }

    // Name of the category - required field
    [Required]
    public string CategoryName { get; set; } = string.Empty;
}
