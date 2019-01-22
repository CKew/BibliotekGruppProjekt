using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryData
{
    public interface IAuthorService
    {
        IQueryable<Author> GetAll();

        IQueryable<Book> GetAllBooksFromAuthor(int authorID);

        IEnumerable<SelectListItem> GetSelectListItems();

        Author GetFromId(int? id);

        void AddAuthor(Author author);
        void Delete(int id);
    }
}
