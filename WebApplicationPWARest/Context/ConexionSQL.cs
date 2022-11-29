
using Microsoft.EntityFrameworkCore;
using WebApplicationPWARest.Modelos;

namespace WebApplicationPWARest.Context
{
    public class ConexionSQL:DbContext
    {
        public ConexionSQL(DbContextOptions<ConexionSQL>options):base(options){

        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Check> Check { get; set; }
        public DbSet<Laboratorios> Laboratorios { get; set; }
        public DbSet<Horarios> Horarios { get; set; }


    }
}

