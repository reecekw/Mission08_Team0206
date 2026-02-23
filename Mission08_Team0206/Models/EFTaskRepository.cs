namespace Mission08_Team0206.Models;

public class EFTaskRepository : ITaskRepository
{
    private readonly TaskContext _context;

    public EFTaskRepository(TaskContext context)
    {
        _context = context;
    }

    public IQueryable<TaskItem> TaskItems => _context.TaskItems;
    public IQueryable<Category> Categories => _context.Categories;

    public void AddTask(TaskItem task)
    {
        _context.TaskItems.Add(task);
        _context.SaveChanges();
    }

    public void UpdateTask(TaskItem task)
    {
        _context.TaskItems.Update(task);
        _context.SaveChanges();
    }

    public void DeleteTask(TaskItem task)
    {
        _context.TaskItems.Remove(task);
        _context.SaveChanges();
    }

    public TaskItem? GetTaskById(int id)
    {
        return _context.TaskItems.Find(id);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
