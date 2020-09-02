using _15_CodeFirst.Entities;
using System.Data.Entity;

namespace _15_CodeFirst
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=defaultConnection")
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
