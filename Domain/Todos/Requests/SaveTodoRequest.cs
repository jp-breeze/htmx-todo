namespace htmx_todo.Domain.Todos.Requests;

public class SaveTodoRequest
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTimeOffset DueDate { get; set; }
}