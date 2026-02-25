using Microsoft.AspNetCore.Mvc;
using Mission08_Team0313.Data;
using Mission08_Team0313.Models;

namespace Mission08_Team0313.Controllers;

public class TasksController : Controller
{
    private readonly ITaskRepository _taskRepo;
    private readonly ICategoryRepository _categoryRepo;

    public TasksController(ITaskRepository taskRepo, ICategoryRepository categoryRepo)
    {
        _taskRepo = taskRepo;
        _categoryRepo = categoryRepo;
    }

    public IActionResult Quadrants()
    {
        var incomplete = _taskRepo.GetIncompleteTasks().ToList();
        var model = incomplete.Select(MapToToDoTask).ToList();
        return View(model);
    }

    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.Categories = _categoryRepo.GetCategories()
            .OrderBy(c => c.CategoryName)
            .Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            });
        return View("AddEdit", new TaskModel { TaskName = "" });
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var task = _taskRepo.GetTaskById(id);
        if (task == null)
            return NotFound();

        ViewBag.Categories = _categoryRepo.GetCategories()
            .OrderBy(c => c.CategoryName)
            .Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            });
        var model = MapToTaskModel(task);
        return View("AddEdit", model);
    }

    [HttpPost]
    public IActionResult Save(TaskModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.TaskId == 0)
            {
                var entry = MapToTaskEntry(model);
                _taskRepo.AddTask(entry);
            }
            else
            {
                var existing = _taskRepo.GetTaskById(model.TaskId);
                if (existing == null)
                    return NotFound();
                existing.Task = model.TaskName;
                existing.DueDate = model.DueDate;
                existing.Quadrant = model.Quadrant;
                existing.CategoryId = model.CategoryId;
                existing.Completed = model.Completed;
                _taskRepo.UpdateTask(existing);
            }
            return RedirectToAction(nameof(Quadrants));
        }

        ViewBag.Categories = _categoryRepo.GetCategories()
            .OrderBy(c => c.CategoryName)
            .Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            });
        return View("AddEdit", model);
    }

    [HttpPost]
    public IActionResult MarkComplete(int id)
    {
        var task = _taskRepo.GetTaskById(id);
        if (task == null)
            return NotFound();
        task.Completed = true;
        _taskRepo.UpdateTask(task);
        return RedirectToAction(nameof(Quadrants));
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var task = _taskRepo.GetTaskById(id);
        if (task == null)
            return NotFound();
        _taskRepo.DeleteTask(task);
        return RedirectToAction(nameof(Quadrants));
    }

    private static ToDoTask MapToToDoTask(TaskEntry t)
    {
        return new ToDoTask
        {
            TaskId = t.TaskId,
            TaskName = t.Task,
            DueDate = t.DueDate,
            Quadrant = t.Quadrant,
            Category = t.Category
        };
    }

    private static TaskModel MapToTaskModel(TaskEntry t)
    {
        return new TaskModel
        {
            TaskId = t.TaskId,
            TaskName = t.Task,
            DueDate = t.DueDate,
            Quadrant = t.Quadrant,
            CategoryId = t.CategoryId,
            Completed = t.Completed
        };
    }

    private static TaskEntry MapToTaskEntry(TaskModel m)
    {
        return new TaskEntry
        {
            TaskId = m.TaskId,
            Task = m.TaskName,
            DueDate = m.DueDate,
            Quadrant = m.Quadrant,
            CategoryId = m.CategoryId,
            Completed = m.Completed
        };
    }
}
