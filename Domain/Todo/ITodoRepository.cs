namespace htmx_test.Domain.Todo;

public interface ITodoRepository
{
    public IEnumerable<Todo> GetAllAsync(CancellationToken ct);
}