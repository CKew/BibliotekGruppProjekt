using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryService
{
    public class LibraryBookService : IBook
    {
        private LibraryContext _context;

        public LibraryBookService(LibraryContext context)
        {
            _context = context;
        }

        // Adds a new unique book.
        public void AddBook(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }

        // Returns all the unique books in the DB.
        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        // Gets all the books from a specific author
        public IEnumerable<Book> GetFromAuthor(int authorId)
        {
            var author = _context.Authors.FirstOrDefault(x => x.ID == authorId);

            var authorBooks = _context.Books.Where(x => x.Author == author);

            return authorBooks;
        }
    }
}
