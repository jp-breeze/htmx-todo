using System.Diagnostics;
using htmx_todo.Domain.Todos;
using htmx_todo.Domain.Todos.Requests;
using htmx_todo.Domain.Todos.Responses;
using Microsoft.AspNetCore.Mvc;
using htmx_todo.Models;

namespace htmx_todo.Service.Controllers;

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

    [HttpGet("create")]
    public IActionResult GetCreate()
    {
        Console.WriteLine("HERE");
        return PartialView("_TodoCardEdit");
    }

    [HttpPut("{id:guid}")]
    public IActionResult SaveEdit(
        [FromServices] ITodoRepository repository,
        [FromServices] TodoService service,
        Guid id,
        SaveTodoRequest request)
    {
        Console.WriteLine(id);
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

        return PartialView("_TodoGallery", service.GetGalleryContent());
    }
    
    [HttpPost("")]
    public IActionResult Create(
        [FromServices] ITodoRepository repository,
        [FromServices] TodoService service,
        CreateTodoRequest request)
    {
        if (request.Title == string.Empty ||
            request.Description == string.Empty)
            return View("Error");
    
        var todo = new Todo
        {
            Title = request.Title,
            Description = request.Description,
            DueDate = request.DueDate
        };
        repository.Create(todo);
        
        return PartialView("_TodoGallery", service.GetGalleryContent());
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(
        [FromServices] ITodoRepository repository,
        [FromServices] TodoService service,
        Guid id)
    {
        var todo = repository.Get(id);
        if (todo is null)
            return View("Error");
        
        repository.Delete(todo.Id);

        return PartialView("_TodoGallery", service.GetGalleryContent());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}