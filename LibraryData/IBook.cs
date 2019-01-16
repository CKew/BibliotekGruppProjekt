using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IBook
    {
        IEnumerable<Book> GetAll();
        Book GetBook(int? bookId);
        IEnumerable<Book> GetAvailable();
        IEnumerable<Book> GetFromAuthor(int authorId);
        IEnumerable<BookCopy> GetBookCopies(int bookId);

        void AddBook(Book book);
        void AddBookCopy(int bookId);
        void Update(Book book);
        bool BookExists(int id);
        void Delete(int id);
    }
}
