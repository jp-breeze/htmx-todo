using System.Diagnostics;
using htmx_test.Domain.Todo;
using Microsoft.AspNetCore.Mvc;
using htmx_test.Models;

namespace htmx_test.Controllers;

public class TodoController : Controller
{
    public IActionResult Index()
    {
        List<TodoResponse> todos =
        [
            new()
            {
                Title = "Workout",
                Description = "Lift: Chest day",
            },
            new() {
                Title = "Take out trash",
                Description = "Go and take out the trash!",
            },
            new() {
                Title = "Cook dinner",
                Description = "You need to eat!",
            },
        ];

        return View(todos);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}