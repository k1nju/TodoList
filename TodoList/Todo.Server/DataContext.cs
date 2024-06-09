using Microsoft.EntityFrameworkCore;
using Todo.Core;

namespace Todo.Server
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<TodoModel> Todos => Set<TodoModel>(); 
    }
}
