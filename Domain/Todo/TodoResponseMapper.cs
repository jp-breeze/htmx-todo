using Riok.Mapperly.Abstractions;

namespace htmx_test.Domain.Todo;

[Mapper]
public partial class TodoResponseMapper
{
    [MapperIgnoreSource("CreatedAt")]
    [MapperIgnoreSource("UpdatedAt")]
    private partial TodoResponse MapToResponse(Todo todo);

    public partial List<TodoResponse> MapToResponseList(List<Todo> todo);
}