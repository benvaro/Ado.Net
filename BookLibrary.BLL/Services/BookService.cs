using BookLibrary.BLL.Model;
using BookLibrary.DAL.Entities;
using BookLibrary.DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> repo;
        private readonly IGenericRepository<Genre> repoGenre;
        private readonly IGenericRepository<Author> repoAuthor;
        public BookService()
        {
            repo = new EFRepository<Book>();
            repoGenre = new EFRepository<Genre>();
            repoAuthor = new EFRepository<Author>();
        }

        public void AddBook(BookDTO book)
        {
            var genre = repoGenre.GetAll().FirstOrDefault(x => x.Name == book.Genre);
            var author = repoAuthor.GetAll().FirstOrDefault(x => x.Name == book.Author);
            var addBook = new Book
            {
                Year = book.Year,
                Title = book.Title,
                Price = book.Price,
                Author = author,
                Genre = genre
            };
            repo.Create(addBook);
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            var books = repo.GetAll();
            var model = new List<BookDTO>();

            foreach (var item in books)
            {
                // mapping
                model.Add(new BookDTO
                {
                    Title = item.Title,
                    Author = item.Author.Name,
                    Genre = item.Genre.Name,
                    Id = item.Id,
                    Price = item.Price,
                    Year = item.Year
                });
            }
            return model;
        }
    }
}
