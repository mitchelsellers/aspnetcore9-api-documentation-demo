using System.ComponentModel.DataAnnotations;

namespace DemoApiProject.Models;

/// <summary>
///     The request object to add a new todo item to the system
/// </summary>
public class CreateTodoRequest
{
    /// <summary>
    ///     The unique title of the Todo item that should be added to the system.
    /// </summary>
    /// <example>Finish API Implementation</example>
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    ///     The description of the Todo item that should be added to the system.
    /// </summary>
    /// <example>I really should make this go to the database</example>
    [Required]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// An optional due date for the item to be completed
    /// </summary>
    [Display(Name="Due Date")]
    public DateTime? DueDate { get; set; }
}