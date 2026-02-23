using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0206.Models;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
    }

    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home" },
            new Category { CategoryId = 2, CategoryName = "School" },
            new Category { CategoryId = 3, CategoryName = "Work" },
            new Category { CategoryId = 4, CategoryName = "Church" }
        );

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
