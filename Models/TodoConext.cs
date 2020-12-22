using Microsoft.EntityFrameworkCore;

namespace LibrosVentaAspnet5.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes {get;set;}
        public DbSet<Libro> Libros {get;set;}        
    }
}
