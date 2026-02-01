using htmx_todo.Domain.Todos;
using htmx_todo.Domain.Todos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace htmx_todo.Service.Controllers;

[Route("home")]
public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index(
        [FromServices] ITodoRepository repository)
    {
        var todos = repository.GetAll().ToList();
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
}