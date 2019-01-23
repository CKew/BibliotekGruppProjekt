using LibraryData.Models;
using System.Linq;

namespace BibliotekGruppProjekt.Models.Books
{
    public class BookDetailModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public IQueryable<BookCopy> BookCopies { get; set; }
        public IQueryable<BookCopy> AvailableBookCopies { get; set; }
    }
}
