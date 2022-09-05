using Microsoft.EntityFrameworkCore;
using SimpleCQRS.API.Model;

namespace SimpleCQRS.API.Context
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<TodoModel> Todos { get; set; }
    }
}
