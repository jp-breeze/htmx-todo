using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using htmx_todo.Domain.Todo;
using htmx_todo.Models;

namespace htmx_todo.Service.Todo;

[Route("todos")]
public class TodoController : Controller
{
    [HttpGet("{id:guid}")]
    public IActionResult Get(
        [FromServices] ITodoRepository repository,
        Guid id)
    {
        var todo = repository.Get(id);

        if (todo is null)
            return View("Error");
        
        var mapped = new TodoResponseMapper().MapToResponse(todo);
        return PartialView("_TodoCard", mapped);
    }

    [HttpGet("{id:guid}/edit")]
    public IActionResult GetEdit(
        [FromServices] ITodoRepository repository,
        Guid id)
    {
        var todo = repository.Get(id);
        
        if (todo is null)
            return View("Error");
        
        var mapped = new TodoResponseMapper().MapToResponse(todo);
        return PartialView("_TodoCardEdit", mapped);
    }

    [HttpPatch("{id:guid}")]
    public IActionResult SaveEdit(
        [FromServices] ITodoRepository repository,
        Guid id,
        SaveTodoRequest request)
    {
        if (request.Id == Guid.Empty ||
            request.Title == string.Empty ||
            request.Description == string.Empty)
            return View("Error");

        var todo = repository.Get(id);
        
        if (todo is null)
            return View("Error");
        
        todo.Title = request.Title;
        todo.Description = request.Description;
        todo.DueDate = request.DueDate;
        repository.Save(todo);

        var mapped = new TodoResponseMapper().MapToResponse(todo);
        
        return PartialView("_TodoCard", mapped);
    }
    
    [HttpPost("/")]
    public IActionResult Create(
        [FromServices] ITodoRepository repository,
        CreateTodoRequest request)
    {
        if (request.Title == string.Empty ||
            request.Description == string.Empty)
            return View("Error.cshtml");

        var todo = new Domain.Todo.Todo
        {
            Title = request.Title,
            Description = request.Description,
            DueDate = request.DueDate
        };
        repository.Create(todo);
        repository.Get(todo.Id);
        return PartialView("_TodoCard", todo);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}