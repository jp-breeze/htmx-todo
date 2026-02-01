namespace htmx_todo.Domain.Todos.Requests;

public class CreateTodoRequest
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTimeOffset DueDate { get; set; }
}