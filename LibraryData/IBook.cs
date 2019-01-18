using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IBook
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetFromAuthor(int authorId);
        IEnumerable<Book> GetAvailable();

        void AddBook(Book book);
    }
}
