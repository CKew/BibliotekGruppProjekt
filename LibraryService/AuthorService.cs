using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryService
{
    public class AuthorService : IAuthorService
    {
        private LibraryContext _context;

        public AuthorService(LibraryContext context)
        {
            _context = context;
        }

        // Returns the author
        public Author GetFromID(int? id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        // Getting all the authors. And including books
        public IQueryable<Author> GetAll()
        {
            return _context.Authors
                .Include(x => x.Books);
        }

        // Adds a new author to the database.
        public void AddAuthor(Author author)
        {
            _context.Add(author);
            _context.SaveChanges();
        }

        // Returns all the books from an author ID.
        public IQueryable<Book> GetAllBooksFromAuthor(int id)
        {
            var author = GetFromID(id);

            return _context.Books.Where(x => x.Author == author);

        }

        // Deletes an author.
        public void Delete(int id)
        {
            var author = _context.Authors.Find(id);
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
