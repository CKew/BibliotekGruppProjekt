using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class BookCopy
    {
        public int Id { get; set; }

        public Book Book { get; set; }

        public bool Status { get; set; }
    }
}
