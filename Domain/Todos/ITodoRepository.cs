namespace htmx_todo.Domain.Todos;

public interface ITodoRepository
{
    public Todo? Get(Guid id);
    public IEnumerable<Todo> GetAll();
    public void Save(Todo todo);
    public void Create(Todo todo);
}