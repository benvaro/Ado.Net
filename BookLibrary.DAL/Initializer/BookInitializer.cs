using BookLibrary.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookLibrary.DAL.Initializer
{
    public class BookInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var genres = new List<Genre>
            {
                new Genre{Name = "IT"},
                new Genre{Name = "Liric"},
                new Genre{Name = "Fantasy"}
            };

            var authors = new List<Author>
            {
                new Author{Name = "R.S. Martin"},
                new Author{Name = "Troelsen"},
                new Author{Name = "A.Friman"},
                new Author{Name = "L.Kostenko"},
                new Author{Name = "M. Kidruk"},
                new Author{Name = "S. King"}
            };

            var books = new List<Book>
            {
                new Book
                {
                    Title = "Clean code",
                    Price = 320,
                    Year = 2019,
                    Author = authors.FirstOrDefault(x=>x.Name=="R.S. Martin"),
                    Genre = genres.FirstOrDefault(x=>x.Name=="IT")
                }
            };

            context.Genres.AddRange(genres);
            context.Authors.AddRange(authors);
            context.Books.AddRange(books);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
