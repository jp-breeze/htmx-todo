using htmx_todo.Domain.Todos;
using Microsoft.AspNetCore.Mvc;

namespace htmx_todo.Service.Controllers;

[Route("home")]
public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index(
        [FromServices] TodoService service)
    {
        ViewBag.Title = "Home";
        return View(service.GetGalleryContent());
    }
}