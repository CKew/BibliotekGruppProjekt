using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryData
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetFromAuthor(int authorID);
        IEnumerable<Book> GetAvailable();
        IQueryable<BookCopy> GetAllBookCopiesFromId(int id);
        IQueryable<BookCopy> GetAllAvailableBookCopiesFromId(int id);

        IQueryable<BookCopy> GetAvailableCopies();

        Book GetFromId(int? id);
        void AddBook(Book book);
        void Delete(int id);
    }
}
