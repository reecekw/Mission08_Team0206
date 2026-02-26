namespace Mission08_Team0206.Models;

// Entity Framework implementation of ITaskRepository
// Uses TaskContext to perform CRUD operations on the SQLite database
public class EFTaskRepository : ITaskRepository
{
    private readonly TaskContext _context;

    // Constructor receives the TaskContext via dependency injection
    public EFTaskRepository(TaskContext context)
    {
        _context = context;
    }

    // Expose task and category data as queryable collections
    public IQueryable<TaskItem> TaskItems => _context.TaskItems;
    public IQueryable<Category> Categories => _context.Categories;

    // Add a new task to the database
    public void AddTask(TaskItem task)
    {
        _context.TaskItems.Add(task);
        _context.SaveChanges();
    }

    // Update an existing task in the database
    public void UpdateTask(TaskItem task)
    {
        _context.TaskItems.Update(task);
        _context.SaveChanges();
    }

    // Delete a task from the database
    public void DeleteTask(TaskItem task)
    {
        _context.TaskItems.Remove(task);
        _context.SaveChanges();
    }

    // Find and return a task by its primary key ID
    public TaskItem? GetTaskById(int id)
    {
        return _context.TaskItems.Find(id);
    }

    // Persist any pending changes to the database
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
