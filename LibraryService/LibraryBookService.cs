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


        public void AddBook(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }

        // Might work might not.
        public void AddBookCopy(int bookId)
        {
            var bookCopy = new BookCopy();
            bookCopy.Books = _context.Books.Find(bookId);
            _context.Add(bookCopy);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        // No way yet to check if book available or not
        public IEnumerable<Book> GetAvailable()
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.ID == bookId);

            return book;
        }

        public IEnumerable<BookCopy> GetBookCopies(int bookId)
        {
            return _context.BookCopies;
        }

        public IEnumerable<Book> GetFromAuthor(int authorId)
        {
            var author = _context.Authors.FirstOrDefault(a => a.ID == authorId);
            var authorBooks = _context.Books.Where(a => a.Author == author);

            return authorBooks;
        }
    }
}
