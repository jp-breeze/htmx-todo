using System.Diagnostics;
using htmx_test.Domain.Todo;
using Microsoft.AspNetCore.Mvc;
using htmx_test.Models;

namespace htmx_test.Service.Todo;

public class TodoController : Controller
{
    public IActionResult Index(
        [FromServices] ITodoRepository repository,
        CancellationToken ct
    )
    {
        var todos = repository.GetAllAsync(ct).ToList();
        var todoResponses = new TodoResponseMapper().MapToResponseList(todos);

        // Sort & Group by Due Date
        var groupedTodos = todoResponses
            .OrderBy(x => x.DueDate)
            .GroupBy(x => x.DueDate.Date)
            .Select(x => new DateGroupedTodoResponse
            {
                DueDate = new DateTimeOffset(x.Key, TimeSpan.Zero),
                TodoList = x.ToList()
            })
            .ToList();

        ViewBag.Title = "Home";
        return View(groupedTodos);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}