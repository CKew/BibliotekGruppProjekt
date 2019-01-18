using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryData;
using LibraryData.Models;

namespace LibraryService
{
    public class LibraryBookCopyService : IBookCopy
    {
        private LibraryContext _context;

        public LibraryBookCopyService(LibraryContext context)
        {
            _context = context;
        }

        // Adds a new copy of an existing book.
        public void AddBookCopy(int bookId)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == bookId);

            var bookCopy = new BookCopy() { Book = book };

            _context.Add(bookCopy);
            _context.SaveChanges();
        }

        // Returns all the copies of a book.
        public IEnumerable<BookCopy> GetCopies(int bookId)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == bookId);

            var bookCopies = _context.BookCopies.Where(x => x.Book == book);

            return bookCopies;
        }
    }
}
