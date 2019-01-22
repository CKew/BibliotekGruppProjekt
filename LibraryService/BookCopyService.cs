using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryData;
using LibraryData.Models;

namespace LibraryService
{
    public class BookCopyService : IBookCopyService
    {
        private LibraryContext _context;

        public BookCopyService(LibraryContext context)
        {
            _context = context;
        }

        // Adds a new copy of an existing book.
        public void AddBookCopy(int id)
        {
            var bookCopy = new BookCopy() {
                BookID = id,
                
            };

            _context.Add(bookCopy);
            _context.SaveChanges();
        }

        public void SetStatusToTrue(Loan loan)
        {
           var bookCopy = _context.BookCopies.FirstOrDefault(x => x.ID == loan.BookCopyID);
            bookCopy.Status = true;
            _context.SaveChanges();
        }

        public void SetStatusToFalse(Loan loan)
        {
            var bookCopy = _context.BookCopies.FirstOrDefault(x => x.ID == loan.BookCopyID);
            bookCopy.Status = false;
            _context.SaveChanges();
        }

        // Returns all the copies of a book.
        public IEnumerable<BookCopy> GetCopies(int bookID)
        {
            var book = _context.Books.FirstOrDefault(x => x.ID == bookID);

            var bookCopies = _context.BookCopies.Where(x => x.Book == book);

            return bookCopies;
        }


    }
}
