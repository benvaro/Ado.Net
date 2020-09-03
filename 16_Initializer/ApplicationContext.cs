namespace _16_Initializer
{
    using _16_Initializer.Entities;
    using _16_Initializer.Initializer;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=ApplicationContext")
        {
            Database.SetInitializer(new GamesInitializer());
        }

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Game> Games { get; set; }

    }

}