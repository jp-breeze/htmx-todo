namespace htmx_todo.Domain.Todo;

public class TodoResponse
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTimeOffset DueDate { get; set; }
    public bool IsActive { get; set; }
}