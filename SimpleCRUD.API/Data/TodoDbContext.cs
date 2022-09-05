using Microsoft.EntityFrameworkCore;
using SimpleCRUD.API.Models;

namespace SimpleCRUD.API.Data
{
    public class TodoDbContext :DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options){}
        public DbSet<Todo> Todos { get; set; }
    }
}
