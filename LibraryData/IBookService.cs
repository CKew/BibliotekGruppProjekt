using LibraryData.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryData
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetFromAuthor(int authorID);
        IEnumerable<Book> GetAvailable();

        IQueryable<BookCopy> GetAvailableCopies();

        Book GetFromID(int? id);
        void AddBook(Book book);
        void Delete(int id);
    }
}
