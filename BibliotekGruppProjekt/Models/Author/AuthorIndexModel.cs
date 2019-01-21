using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Models.Author
{
    public class AuthorIndexModel
    {
        public IQueryable<LibraryData.Models.Author> Authors { get; set; }
    }
}
