using System.Data.Entity;

namespace Vidly.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Costumer> Costumers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}