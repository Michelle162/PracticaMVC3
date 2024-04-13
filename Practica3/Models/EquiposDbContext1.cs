using Microsoft.EntityFrameworkCore;

namespace Practica3.Models
{
    public class EquiposDbContext1 : EquiposDbContext
    {
        public EquiposDbContext1(DbContextOptions options) : base(options)
        {
        }

        public DbSet<marcas> marcas { get; set; }
        public DbSet<tipo_equipo> tipo_Equipo { get; set; }
        public DbSet<estados_equipo> estados_equipo { get; set; }
        public DbSet<equipos> equipos { get; set; }
    }
}
}
