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
    public class AuthorService : IAuthorService
    {
        private LibraryContext _context;

        public AuthorService(LibraryContext context)
        {
            _context = context;
        }

        // Returns the author
        public Author GetFromId(int? Id)
        {
            return GetAll().FirstOrDefault(x => x.ID == Id);
        }

        // Eager loading books
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

        // Returns all the books by a specified author.
        public IQueryable<Book> GetAllBooksFromAuthor(int authorId)
        {
            var author = GetFromId(authorId);

            return _context.Books.Where(x => x.Author == author);

        }
        
        // Not quite sure what it does. But it makes the items available in the index model. Probably due to eager loading.
        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            return _context.Authors.ToList().OrderBy(x => x.ID).Select(x =>
                   new SelectListItem
                   {
                       Text = $"{x.Name}",
                       Value = x.ID.ToString()
                   });
        }

        // Deletes the specific author 
        public void Delete(int id)
        {
            var author = _context.Authors.Find(id);
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
