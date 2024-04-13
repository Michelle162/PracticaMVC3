using Microsoft.EntityFrameworkCore;

namespace Practica3.Models
{
    public class EquiposDbContext : DbContext
    {

            public EquiposDbContext(DbContextOptions options) : base(options)
            {
            }

            public DbSet<marcas> marcas { get; set; }
            public DbSet<equipos> equipos { get; set; }
        
    }
}
