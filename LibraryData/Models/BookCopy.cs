using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryData.Models
{
    public class BookCopy
    {
        public int ID { get; set; }

        [ForeignKey("Book")]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }

        public bool Status { get; set; }
    }
}
