using Microsoft.EntityFrameworkCore;
using TestWebAPI.Data;
using TestWebAPI.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDB>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/todoItems", async (TodoDB dB) => await dB.Todos.ToListAsync());
app.MapGet("/todoItems/Complete", async (TodoDB dB) => await dB.Todos.Where(r => r.IsCompleted).ToListAsync());
app.MapGet("/todoItems/{id}", async (int id, TodoDB dB) => await dB.Todos.FindAsync()
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound());
app.MapPost("/todoItems", async (Todo todo, TodoDB dB) =>
{
    dB.Todos.Add(todo);
    await dB.SaveChangesAsync();

    return Results.Created($"/todoItems/{todo.Id}", todo);
});

app.Run();