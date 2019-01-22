using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryData
{
    public interface IBook
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetFromAuthor(int authorId);
        IEnumerable<Book> GetAvailable();
        IQueryable<BookCopy> GetAllBookCopiesFromId(int Id);
        IQueryable<BookCopy> GetAllAvailableBookCopiesFromId(int Id);

        IQueryable<BookCopy> GetAvailableCopies();

        Book GetFromId(int? Id);
        void AddBook(Book book);
        void Delete(int id);
    }
}
