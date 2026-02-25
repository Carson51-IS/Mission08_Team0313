namespace Mission08_Team0313.Models;

/// <summary>
/// Category for tasks. Populates the dropdown (Home, School, Work, Church).
/// </summary>
public class Category
{
    public int CategoryId { get; set; }
    public required string CategoryName { get; set; }

    // Navigation property: one category has many tasks
    public ICollection<TaskEntry> Tasks { get; set; } = new List<TaskEntry>();
}
