namespace BookLibrary.DAL
{
    using BookLibrary.DAL.Entities;
    using BookLibrary.DAL.Initializer;
    using System.Data.Entity;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=ApplicationContext")
        {
            Database.SetInitializer(new BookInitializer());
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }

}