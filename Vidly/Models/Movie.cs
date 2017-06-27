using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Costumer> Costumers { get; set; }
    }
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}