using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryService
{
    public class BookService : IBookService
    {
        private LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        // Gets a book from ID
        public Book GetFromID(int? id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        // Adds a new book and adds a bookCopy of it.
        public void AddBook(Book book)
        {
            var bookCopyService = new BookCopyService(_context);
            _context.Add(book);
            _context.SaveChanges();
            bookCopyService.AddBookCopy(book.ID);
        }

        // Returns all the books in the DB. Includes Author and BookCopies
        public IEnumerable<Book> GetAll()
        {
            return _context.Books
                .Include(x => x.Author)
                .Include(x => x.BookCopies);
        }

        // Gets all the books from a specific author
        public IEnumerable<Book> GetFromAuthor(int authorID)
        {
            var author = _context.Authors.FirstOrDefault(x => x.ID == authorID);

            return GetAll().Where(x => x.Author == author);

        }

        // Gets all the available books. Includes Author.
        public IEnumerable<Book> GetAvailable()
        {
            var availableBookCopies = _context.BookCopies.Where(x => x.Status == false);

            return availableBookCopies.Select(x => x.Book)
                .Include(x => x.Author);

        }

        // Gets all available bookCopies (used when displaying a dropdown in View models)
        public IQueryable<BookCopy> GetAvailableCopies()
        {
            return _context.BookCopies.Where(x => x.Status == false)
                .Include(x => x.Book);
        }

        // Deletes the specific book
        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
