using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Author
    {
        public int ID { get; set; }

        public string Name { get; set; }
        
        public virtual IEnumerable<Book> Books { get; set; }
    }
}
