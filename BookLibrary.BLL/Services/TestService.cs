using AutoMapper;
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
       static List<Book> test = new List<Book>();
       static List<Genre> genres = new List<Genre>();
       static List<Author> authors = new List<Author>();
        private readonly IMapper mapper;
        public TestService(IMapper _mapper)
        {
            mapper = _mapper;
             genres = new List<Genre>
            {
                new Genre{Name = "IT"},
                new Genre{Name = "Liric"},
                new Genre{Name = "Fantasy"}
            };

             authors = new List<Author>
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
            return mapper.Map<ICollection<BookDTO>>(test);
           
        }
    }
}
