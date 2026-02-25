using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0313.Models;

/// <summary>
/// View model for Add/Edit task form.
/// </summary>
public class TaskModel
{
    public int TaskId { get; set; }

    [Required(ErrorMessage = "Task description is required.")]
    [Display(Name = "Task")]
    public required string TaskName { get; set; }

    [Display(Name = "Due Date")]
    public DateTime? DueDate { get; set; }

    [Required(ErrorMessage = "Quadrant is required.")]
    [Range(1, 4, ErrorMessage = "Quadrant must be 1, 2, 3, or 4.")]
    [Display(Name = "Quadrant")]
    public int Quadrant { get; set; }

    [Display(Name = "Category")]
    public int? CategoryId { get; set; }

    [Display(Name = "Completed")]
    public bool Completed { get; set; }
}
