namespace Mission08_Team0313.Models;

/// <summary>
/// View model for displaying a task in the Quadrants matrix and task lists.
/// </summary>
public class ToDoTask
{
    public int TaskId { get; set; }
    public required string TaskName { get; set; }
    public DateTime? DueDate { get; set; }
    public int Quadrant { get; set; }
    public Category? Category { get; set; }
}
