using htmx_test.Domain.Todo;

namespace htmx_todo.Data.Todo;

public class TodoRepository : ITodoRepository
{
    private readonly List<htmx_test.Domain.Todo.Todo> _db =
    [
        new()
        {
            Title = "Schedule dentist appointment",
            Description = "Call Dr. Smith's office to book a cleaning and checkup",
            DueDate = DateTimeOffset.UtcNow,
            IsActive = true,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
        },
        new()
        {
            Title = "Review quarterly budget",
            Description = "Analyze Q1 spending and adjust budget categories for Q2",
            DueDate = DateTimeOffset.UtcNow.AddDays(1),
            IsActive = true,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
        },
        new()
        {
            Title = "Update resume",
            Description = "Add recent projects and certifications to LinkedIn and resume",
            DueDate = DateTimeOffset.UtcNow.AddDays(2),
            IsActive = true,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
        },
        new()
        {
            Title = "Meal prep for the week",
            Description = "Prepare lunches and dinners for Monday through Friday",
            DueDate = DateTimeOffset.UtcNow.AddDays(2),
            IsActive = true,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
        },
        new()
        {
            Title = "Complete online course module",
            Description = "Finish Module 4 of the C# Advanced Patterns course",
            DueDate = DateTimeOffset.UtcNow.AddDays(3),
            IsActive = true,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
        }
    ];
    
    public IEnumerable<htmx_test.Domain.Todo.Todo> GetAllAsync(CancellationToken ct)
    {
        return _db.Where(x => x.IsActive);
    }
}