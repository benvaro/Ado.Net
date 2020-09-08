using BookLibrary.BLL.Model;
using BookLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.BLL.Services
{
    public class TestService : IBookService
    {
        List<Book> test = new List<Book>();
        public TestService()
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

           test = new List<Book>
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
        }
        
        public void AddBook(BookDTO book)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            return null;
           
        }
    }
}
