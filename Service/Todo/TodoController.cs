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
        var mapped = new TodoResponseMapper().MapToResponse(todo);
        return PartialView("_TodoCard.cshtml", mapped);
    }

    [HttpGet("{id:guid}/edit")]
    public IActionResult GetEdit(
        [FromServices] ITodoRepository repository,
        Guid id)
    {
        var todo = repository.Get(id);
        var mapped = new TodoResponseMapper().MapToResponse(todo);
        return PartialView("_TodoCardEdit.cshtml", mapped);
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
            return View("Error.cshtml");

        var todo = repository.Get(id);
        todo.Title = request.Title;
        todo.Description = request.Description;
        todo.DueDate = request.DueDate;
        repository.Save(todo);
        
        return PartialView("_TodoCard.cshtml", todo);
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
        return PartialView("_TodoCard.cshtml", todo);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}