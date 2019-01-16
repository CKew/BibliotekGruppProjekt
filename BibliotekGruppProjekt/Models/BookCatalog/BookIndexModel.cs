using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Models.BookCatalog
{
    public class BookIndexModel
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
