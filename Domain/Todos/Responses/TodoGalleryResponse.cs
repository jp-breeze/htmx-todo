namespace htmx_todo.Domain.Todos.Responses;

public class TodoGalleryResponse
{
    public required List<TodoGroupResponse> Groups { get; set; }
}