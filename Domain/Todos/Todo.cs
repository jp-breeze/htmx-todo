namespace htmx_todo.Domain.Todos;

public class Todo
{
    public Guid Id { get; } = Guid.NewGuid();
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTimeOffset DueDate { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}