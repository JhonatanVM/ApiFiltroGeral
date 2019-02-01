using ApiFiltroGeral.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFiltroGeral.Context
{
    public class BuscaContext : DbContext
    {
        public DbSet<Uf> Uf { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=.;Initial Catalog=Nome;Integrated Security=True");
        }
    }
}
