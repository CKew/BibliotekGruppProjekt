using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Member
    {
        public int ID { get; set; }

        [Required]
        [RegularExpression(@"^[0-9\s]{10,12}$", ErrorMessage = " must be a number and between 10-12 characters")]
        public string PersonNr { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Fees { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }

    }
}
