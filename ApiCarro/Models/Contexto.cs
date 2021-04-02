using Microsoft.EntityFrameworkCore;

namespace ApiCarro.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Carro> Carros { get; set; }

        public Contexto(DbContextOptions<Contexto> options) :base(options)
        {
            
        }
    }
}