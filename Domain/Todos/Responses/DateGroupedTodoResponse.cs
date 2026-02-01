namespace htmx_todo.Domain.Todos.Responses;

public class DateGroupedTodoResponse
{
    public required DateTimeOffset DueDate { get; set; }
    public required List<TodoResponse> TodoList {  get; set; }
}