using AutoMapper;
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
        private readonly IMapper mapper;
        public BookService(IGenericRepository<Book> _repo,
                           IGenericRepository<Genre> _repoGenre,
                           IGenericRepository<Author> _repoAuthor,
                           IMapper _mapper)
        {
            repo = _repo;
            repoGenre = _repoGenre;
            repoAuthor = _repoAuthor;
            mapper = _mapper;
        }

        public void AddBook(BookDTO book)
        {
            var addBook = mapper.Map<Book>(book);
            var genre = repoGenre.GetAll().FirstOrDefault(x => x.Name == book.Genre);
            var author = repoAuthor.GetAll().FirstOrDefault(x => x.Name == book.Author);
            #region manual mapping
            //var addBook = new Book
            //{
            //    Year = book.Year,
            //    Title = book.Title,
            //    Price = book.Price,
            //    Author = author,
            //    Genre = genre
            //}; 
            #endregion
            addBook.Author = author;
            addBook.Genre = genre;
            repo.Create(addBook);
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            var books = repo.GetAll();
            #region manual mapping
            // var model = new List<BookDTO>();

            //foreach (var item in books)
            //{
            //    // mapping
            //    model.Add(new BookDTO
            //    {
            //        Title = item.Title,
            //        Author = item.Author.Name,
            //        Genre = item.Genre.Name,
            //        Id = item.Id,
            //        Price = item.Price,
            //        Year = item.Year
            //    });
            //}

            #endregion
            var model = mapper.Map<ICollection<BookDTO>>(books);
            return model;
        }
    }
}
