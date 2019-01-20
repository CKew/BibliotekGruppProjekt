using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Models.Library
{
    public class BookDetailModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public int ISBN { get; set; }
        public ICollection<BookCopy> BookCopies { get; set; }
    }
}
