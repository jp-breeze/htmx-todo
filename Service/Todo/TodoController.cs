using System.Diagnostics;
using htmx_test.Domain.Todo;
using Microsoft.AspNetCore.Mvc;
using htmx_test.Models;

namespace htmx_test.Service.Todo;

public class TodoController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Title = "Home";
        List<TodoResponse> todos =
        [
            new TodoResponse
            {
                Title = "Schedule dentist appointment",
                Description = "Call Dr. Smith's office to book a cleaning and checkup",
                DueDate = DateTimeOffset.UtcNow
            },
            new TodoResponse
            {
                Title = "Review quarterly budget",
                Description = "Analyze Q1 spending and adjust budget categories for Q2",
                DueDate = DateTimeOffset.UtcNow.AddDays(1)
            },
            new TodoResponse
            {
                Title = "Update resume",
                Description = "Add recent projects and certifications to LinkedIn and resume",
                DueDate = DateTimeOffset.UtcNow.AddDays(2)
            },
            new TodoResponse
            {
                Title = "Meal prep for the week",
                Description = "Prepare lunches and dinners for Monday through Friday",
                DueDate = DateTimeOffset.UtcNow.AddDays(2)
            },
            new TodoResponse
            {
                Title = "Complete online course module",
                Description = "Finish Module 4 of the C# Advanced Patterns course",
                DueDate = DateTimeOffset.UtcNow.AddDays(3)
            }
        ];

        var groupedTodos = todos
            .OrderBy(x => x.DueDate)
            .GroupBy(x => x.DueDate.Date)
            .Select(x => new DateGroupedTodoResponse
            {
                DueDate = new DateTimeOffset(x.Key, TimeSpan.Zero),
                TodoList = x.ToList()
            })
            .ToList();

        return View(groupedTodos);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}