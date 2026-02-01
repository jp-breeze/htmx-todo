using Riok.Mapperly.Abstractions;

namespace htmx_todo.Domain.Todos.Responses;

[Mapper]
public partial class TodoResponseMapper
{
    [MapperIgnoreSource("CreatedAt")]
    [MapperIgnoreSource("UpdatedAt")]
    public partial TodoResponse MapToResponse(Todo todo);

    public partial List<TodoResponse> MapToResponseList(List<Todo> todo);
}