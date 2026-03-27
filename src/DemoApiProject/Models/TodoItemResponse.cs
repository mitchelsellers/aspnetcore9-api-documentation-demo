using System.ComponentModel;

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
    /// What type of item am I creating
    /// </summary>
    public TodoItemType ItemType { get; set; }

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

/// <remarks>
/// This example shows how you can use the "Description" field to push data into ReDoc
/// </remarks>
public enum TodoItemType
{
    /// <summary>
    /// Represents a general task that does not meet any specific category.
    /// </summary>
    [Description("General tasks - meets nothing specific otherwise")]
    Task = 1,
    /// <summary>
    /// Administrative tasks, not customer facing
    /// </summary>
    [Description("Administrative tasks - for internal task management")]
    Administrative = 2,
    /// <summary>
    /// Personal tasks, not for sharing
    /// </summary>
    [Description("Personal tasks - for non-sharing of tasks")]
    Personal = 3,
    /// <summary>
    /// Items for accounting purposes.
    /// </summary>
    [Description("Accounting tasks - for items needing attention of accounting")]
    Accounting = 4
}