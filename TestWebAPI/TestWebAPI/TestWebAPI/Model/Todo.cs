using Microsoft.EntityFrameworkCore;


namespace TestWebAPI.Model
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; }
    }
}
