using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Models.Books
{
    public class BookIndexModel
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<LibraryData.Models.Author> Authors { get; set; }
    }
}
