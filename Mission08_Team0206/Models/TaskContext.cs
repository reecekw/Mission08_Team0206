using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0206.Models;

// Database context class for Entity Framework Core
// Manages the connection to the SQLite database and provides access to TaskItems and Categories
public class TaskContext : DbContext
{
    // Constructor accepts options configured in Program.cs (connection string, etc.)
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
    }

    // DbSet for the TaskItems table
    public DbSet<TaskItem> TaskItems { get; set; }

    // DbSet for the Categories table
    public DbSet<Category> Categories { get; set; }

    // Seed the database with initial data for categories and sample tasks
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed the four category options for the dropdown
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home" },
            new Category { CategoryId = 2, CategoryName = "School" },
            new Category { CategoryId = 3, CategoryName = "Work" },
            new Category { CategoryId = 4, CategoryName = "Church" }
        );

        // Seed some sample tasks to demonstrate the app
        modelBuilder.Entity<TaskItem>().HasData(
            new TaskItem
            {
                TaskItemId = 1,
                TaskDescription = "Finish Mission 08 project",
                DueDate = new DateTime(2026, 3, 1),
                Quadrant = 1,
                CategoryId = 2,
                Completed = false
            },
            new TaskItem
            {
                TaskItemId = 2,
                TaskDescription = "Clean the kitchen",
                DueDate = new DateTime(2026, 2, 25),
                Quadrant = 3,
                CategoryId = 1,
                Completed = false
            },
            new TaskItem
            {
                TaskItemId = 3,
                TaskDescription = "Plan career goals",
                DueDate = null,
                Quadrant = 2,
                CategoryId = 3,
                Completed = false
            }
        );
    }
}
