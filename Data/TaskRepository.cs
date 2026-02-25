using Microsoft.EntityFrameworkCore;
using Mission08_Team0313.Models;

namespace Mission08_Team0313.Data;

public class TaskRepository : ITaskRepository
{
    private readonly TaskContext _context;

    public TaskRepository(TaskContext context)
    {
        _context = context;
    }

    public IQueryable<TaskEntry> GetIncompleteTasks()
    {
        return _context.Tasks
            .Where(t => !t.Completed)
            .Include(t => t.Category);
    }

    public TaskEntry? GetTaskById(int id)
    {
        return _context.Tasks
            .Include(t => t.Category)
            .FirstOrDefault(t => t.TaskId == id);
    }

    public void AddTask(TaskEntry task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public void UpdateTask(TaskEntry task)
    {
        _context.Tasks.Update(task);
        _context.SaveChanges();
    }

    public void DeleteTask(TaskEntry task)
    {
        _context.Tasks.Remove(task);
        _context.SaveChanges();
    }
}
