﻿using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryService
{
    public class LibraryAuthorService : IAuthor
    {
        private LibraryContext _context;

        public LibraryAuthorService(LibraryContext context)
        {
            _context = context;
        }

        // Adds a new author to the database.
        public void AddAuthor(Author author)
        {
            _context.Add(author);
            _context.SaveChanges();
        }

        // Returns all the books by a specified author.
        public IEnumerable<Book> GetAllBooksFromAuthor(int authorId)
        {
            var author = _context.Authors.FirstOrDefault(x => x.ID == authorId);

            var authorBooks = _context.Books.Where(x => x.Author == author);

            return authorBooks;
        }
    }
}
