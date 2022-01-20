using Microsoft.EntityFrameworkCore;
using TestWebAPI.Data;
using TestWebAPI.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDB>(opt => opt.UseInMemoryDatabase("TodoList"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/todoitems", async (TodoDB db) =>
    await db.Todos.ToListAsync());

app.MapGet("/todoitems/complete", async (TodoDB db) =>
    await db.Todos.Where(t => t.IsCompleted).ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, TodoDB db) =>
    await db.Todos.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound());

app.MapGet("/todoItems/CreatedDate", async (TodoDB db) => 
    await db.Todos.ToListAsync());

app.MapPost("/todoitems", async (Todo todo, TodoDB db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.Run();