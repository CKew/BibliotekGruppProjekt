using LibraryData.Models;
using System.Collections.Generic;

namespace BibliotekGruppProjekt.Models.Books
{
    public class BookIndexModel
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<LibraryData.Models.Author> Authors { get; set; }
    }
}
