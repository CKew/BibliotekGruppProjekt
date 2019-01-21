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

        public ICollection<BookCopy> GetAllBookCopies(int Id)
        {
            return GetFromId(Id).BookCopies;
        }

        public Book GetFromId(int Id)
        {
            return GetAll().FirstOrDefault(x => x.Id == Id);
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
            return _context.Books
                .Include(x => x.Author)
                .Include(x => x.BookCopies);
        }

        
        // Gets all the books from a specific author
        public IEnumerable<Book> GetFromAuthor(int authorId)
        {
            var author = _context.Authors.FirstOrDefault(x => x.ID == authorId);

            return _context.Books.Where(x => x.Author == author);

        }

        public IEnumerable<Book> GetAvailable()
        {
            var availableBookCopies = _context.BookCopies.Where(x => x.Status == false);

            return availableBookCopies.Select(x => x.Book)
                .Include(x => x.Author);

        }

        //public bool IsAvailable(Book book)
        //{
        //    var availableBookCopies = _context.BookCopies.Where(x => x.Status == false);
        //    var availableBooks = _context.Books.Where(x => x.BookCopies.)
        //}
    }
}
