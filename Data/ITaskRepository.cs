using Mission08_Team0313.Models;

namespace Mission08_Team0313.Data;

public interface ITaskRepository
{
    IQueryable<TaskEntry> GetIncompleteTasks();
    TaskEntry? GetTaskById(int id);
    void AddTask(TaskEntry task);
    void UpdateTask(TaskEntry task);
    void DeleteTask(TaskEntry task);
}
