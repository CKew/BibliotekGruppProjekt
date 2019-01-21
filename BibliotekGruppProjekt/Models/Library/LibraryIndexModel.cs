using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Models.Library
{
    public class LibraryIndexModel
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
