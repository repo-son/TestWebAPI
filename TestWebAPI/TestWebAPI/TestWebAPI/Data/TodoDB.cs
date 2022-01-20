using Microsoft.EntityFrameworkCore;
using TestWebAPI.Model;

namespace TestWebAPI.Data
{
    public class TodoDB : DbContext
    {
        public TodoDB(DbContextOptions<TodoDB> options): base(options) 
        {

        }
        public DbSet<Todo> Todos => Set<Todo>();
    }
}
