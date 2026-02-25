using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0313.Models;

/// <summary>
/// A task on the Quadrant to-do list.
/// Quadrant: 1 = Important/Urgent, 2 = Important/Not Urgent, 3 = Not Important/Urgent, 4 = Not Important/Not Urgent.
/// </summary>
public class TaskEntry
{
    public int TaskId { get; set; }

    [Required(ErrorMessage = "Task description is required.")]
    public required string Task { get; set; }

    public DateTime? DueDate { get; set; }

    [Required(ErrorMessage = "Quadrant is required.")]
    [Range(1, 4, ErrorMessage = "Quadrant must be 1, 2, 3, or 4.")]
    public int Quadrant { get; set; }

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public bool Completed { get; set; }
}
