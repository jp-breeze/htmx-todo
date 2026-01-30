namespace htmx_todo.Domain.Todo;

public interface ITodoRepository
{
    public IEnumerable<Todo> GetAllAsync(CancellationToken ct);
}