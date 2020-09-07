using BookLibrary.BLL.Model;
using System.Collections.Generic;

namespace BookLibrary.BLL.Services
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetBooks();
        void AddBook(BookDTO book);
    }
}
