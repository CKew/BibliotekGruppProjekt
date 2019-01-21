using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Models.Author
{
    public class AuthorDetailModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual IQueryable<Book> Books { get; set; }
    }
}
