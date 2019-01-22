using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        // Gets all the available bookcopies from a book
        public IQueryable<BookCopy> GetAllAvailableBookCopiesFromId(int Id)
        {
            return GetAllBookCopiesFromId(Id).Where(x => x.Status == false);
        }
        // Gets all bookCopies From a book
        public IQueryable<BookCopy> GetAllBookCopiesFromId(int Id)
        {
            
            return _context.BookCopies.Where(x => x.BookId == Id);
        }

        public Book GetFromId(int? Id)
        {
            return GetAll().FirstOrDefault(x => x.Id == Id);
        }

        // Adds a new unique book.
        public void AddBook(Book book)
        {
            var bookCopyService = new LibraryBookCopyService(_context);
            _context.Add(book);
            _context.SaveChanges();
            bookCopyService.AddBookCopy(book.Id);
        }

        // Returns all the unique books in the DB.
        public IEnumerable<Book> GetAll()
        {
            return _context.Books
                .Include(x => x.Author)
                .Include(x => x.AvailableBookCopies);
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


        //public bool IsAvailable(Book book)
        //{
        //    var availableBookCopies = _context.BookCopies.Where(x => x.Status == false);
        //    var availableBooks = _context.Books.Where(x => x.BookCopies.)
        //}
    }
}
