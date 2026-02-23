namespace Mission08_Team0206.Models;

public interface ITaskRepository
{
    IQueryable<TaskItem> TaskItems { get; }
    IQueryable<Category> Categories { get; }

    void AddTask(TaskItem task);
    void UpdateTask(TaskItem task);
    void DeleteTask(TaskItem task);

    TaskItem? GetTaskById(int id);
    void SaveChanges();
}
