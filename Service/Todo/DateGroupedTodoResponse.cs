using htmx_todo.Domain.Todo;

namespace htmx_todo.Service.Todo;

public class DateGroupedTodoResponse
{
    public required DateTimeOffset DueDate { get; set; }
    public required List<TodoResponse> TodoList {  get; set; }
}