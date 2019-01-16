using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Models.BookCatalog
{
    public class BookDetailModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public int ISBN { get; set; }
        public BookCopy BookCopy { get; set; }
    }
}
