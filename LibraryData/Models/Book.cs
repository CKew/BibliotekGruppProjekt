using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        public int ISBN { get; set; }

        [Required]
        public Author Author { get; set; }
        // By adding this AuthorID(this is the foreign key) i am setting this class as the child of the relationship.
        public int AuthorID { get; set; }

        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public IEnumerable<BookCopy> BookCopies { get; set; }


        public string Description { get; set; }

    }
}
