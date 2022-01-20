using Microsoft.EntityFrameworkCore;
using TestWebAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDB>(opt => opt.UseInMemoryDatabase("TodoList"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();