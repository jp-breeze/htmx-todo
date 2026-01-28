using htmx_test.Domain.Todo;

namespace htmx_test.Service.Todo;

public class DateGroupedTodoResponse
{
    public required DateTimeOffset DueDate { get; set; }
    public required List<TodoResponse> TodoList {  get; set; }
}