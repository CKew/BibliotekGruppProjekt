using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryData.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"^[0-9\s]{10}$", ErrorMessage = " must be a number and consist of 10 characters")]
        public string ISBN { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<BookCopy> BookCopies { get; set; }

        [Required]
        [ForeignKey("Author")]
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }

    }
}
