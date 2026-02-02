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
        
        var todos = repository.GetAll().ToList();
        var todoResponses = new TodoResponseMapper().MapToResponseList(todos);

        var groupedTodos = todoResponses
            .OrderBy(x => x.DueDate)
            .GroupBy(x => x.DueDate.Date)
            .Select(x => new DateGroupedTodoResponse
            {
                DueDate = new DateTimeOffset(x.Key, TimeSpan.Zero),
                TodoList = x.ToList()
            })
            .ToList();
        
        return PartialView("_TodoGallery", groupedTodos);
    }
    
    [HttpPost("")]
    public IActionResult Create(
        [FromServices] ITodoRepository repository,
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
        
        var todos = repository.GetAll().ToList();
        var todoResponses = new TodoResponseMapper().MapToResponseList(todos);

        var groupedTodos = todoResponses
            .OrderBy(x => x.DueDate)
            .GroupBy(x => x.DueDate.Date)
            .Select(x => new DateGroupedTodoResponse
            {
                DueDate = new DateTimeOffset(x.Key, TimeSpan.Zero),
                TodoList = x.ToList()
            })
            .ToList();
        
        
        return PartialView("_TodoGallery", groupedTodos);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(
        [FromServices] ITodoRepository repository,
        Guid id)
    {
        var todo = repository.Get(id);
        if (todo is null)
            return View("Error");
        
        repository.Delete(todo.Id);
        
        var todos = repository.GetAll().ToList();
        var todoResponses = new TodoResponseMapper().MapToResponseList(todos);

        var groupedTodos = todoResponses
            .OrderBy(x => x.DueDate)
            .GroupBy(x => x.DueDate.Date)
            .Select(x => new DateGroupedTodoResponse
            {
                DueDate = new DateTimeOffset(x.Key, TimeSpan.Zero),
                TodoList = x.ToList()
            })
            .ToList();

        return PartialView("_TodoGallery", groupedTodos);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}