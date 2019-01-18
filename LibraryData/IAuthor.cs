using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IAuthor
    {
        IEnumerable<Book> GetAllBooksFromAuthor(int authorId);

        IEnumerable<SelectListItem> GetSelectListItems();

        void AddAuthor(Author author);
    }
}
