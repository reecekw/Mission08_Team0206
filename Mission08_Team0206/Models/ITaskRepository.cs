namespace Mission08_Team0206.Models;

// Repository pattern interface for accessing task and category data
// Abstracts the data access layer so the controller doesn't depend directly on EF Core
public interface ITaskRepository
{
    // Queryable collections for reading tasks and categories
    IQueryable<TaskItem> TaskItems { get; }
    IQueryable<Category> Categories { get; }

    // CRUD operations for tasks
    void AddTask(TaskItem task);
    void UpdateTask(TaskItem task);
    void DeleteTask(TaskItem task);

    // Retrieve a single task by its ID
    TaskItem? GetTaskById(int id);

    // Persist any pending changes to the database
    void SaveChanges();
}
