using htmx_todo.Domain.Todos.Responses;

namespace htmx_todo.Domain.Todos;

public class TodoService(ITodoRepository repository)
{
    public TodoGalleryResponse GetGalleryContent()
    {
        var todos = repository.GetAll().ToList();
        var todoResponses = new TodoResponseMapper().MapToResponseList(todos);

        var groupedTodos = todoResponses
            .OrderBy(x => x.DueDate)
            .GroupBy(x => x.DueDate.Date)
            .Select(x => new TodoGroupResponse
            {
                DueDate = new DateTimeOffset(x.Key, TimeSpan.Zero),
                TodoList = x.ToList()
            })
            .ToList();
        
        return new TodoGalleryResponse { Groups = groupedTodos };
    }
}