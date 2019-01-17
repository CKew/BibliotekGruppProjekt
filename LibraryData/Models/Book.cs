using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Book
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public string Description { get; set; }

        public IEnumerable<BookCopy> BookCopies { get; set; }

        public Author Author { get; set; }

    }
}
