using MarioAndresJaramillo.Models;
using Microsoft.EntityFrameworkCore;

namespace MarioAndresJaramillo
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Turno> Turnos { get; set; }
    }
    
}
