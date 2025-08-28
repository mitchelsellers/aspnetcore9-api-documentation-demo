namespace DemoApiProject.Models;

/// <summary>
///     Represents a single Todo item
/// </summary>
public class TodoItemResponse
{
    /// <summary>
    ///     The unique identifier of the Todo item
    /// </summary>
    public Guid TodoId { get; set; }

    /// <summary>
    ///     The unique title of the Todo item that should be added to the system.
    /// </summary>
    /// <example>Finish API Implementation</example>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    ///     The description of the Todo item that should be added to the system.
    /// </summary>
    /// <example>I really should make this go to the database</example>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     An optional due date for the item to be completed
    /// </summary>
    public DateTime? DueDate { get; set; }
}