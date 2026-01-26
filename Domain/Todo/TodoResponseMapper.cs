using Riok.Mapperly.Abstractions;

namespace htmx_test.Domain.Todo;

[Mapper]
public partial class TodoResponseMapper
{
    [MapperIgnoreSource("CreatedAt")]
    [MapperIgnoreSource("UpdatedAt")]
    public partial TodoResponse MapToResponse(Todo todo);
}