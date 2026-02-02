# htmx-todo

A simple todo app demonstrating **ASP.NET Core MVC + HTMX** for building dynamic web UIs without heavy JavaScript frameworks.

## Tech Stack

- **.NET 10** / ASP.NET Core MVC
- **HTMX** - HTML-driven interactivity
- **Riok.Mapperly** - Source-generated object mapping
- **WebOptimizer** - CSS bundling

## Project Structure

```
├── Service/    # Web layer (controllers, views, static assets)
├── Domain/     # Business logic, entities, DTOs
├── Data/       # Repository layer (in-memory storage)
```

## Getting Started

```bash
# Restore dependencies
dotnet restore

# Run the application
dotnet run --project Service

# Navigate to http://localhost:5000/home
```

## Features

- Create, edit, and delete todos
- Todos grouped by due date
- Partial page updates via HTMX (no full reloads)
- Soft deletes for data integrity

## HTMX in Action

The app uses HTMX attributes to handle interactions:

```html
<!-- Edit swaps in a form -->
<button hx-get="/todos/{id}/edit" hx-target="#todo-{id}">Edit</button>

<!-- Delete refreshes the gallery -->
<button hx-delete="/todos/{id}" hx-target="#todo-gallery">Delete</button>

<!-- Save updates the gallery -->
<button hx-put="/todos/{id}" hx-target="#todo-gallery">Save</button>
```

## Notes

- Uses in-memory storage (data resets on restart)
- Database packages (Dapper, Npgsql) included for easy PostgreSQL upgrade