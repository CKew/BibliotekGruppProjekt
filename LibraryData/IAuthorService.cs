using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace LibraryData
{
    public interface IAuthorService
    {
        IQueryable<Author> GetAll();

        IQueryable<Book> GetAllBooksFromAuthor(int Id);

        Author GetFromID(int? id);
        void AddAuthor(Author author);
        void Delete(int id);
    }
}
