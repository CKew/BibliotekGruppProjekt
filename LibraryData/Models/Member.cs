using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Member
    {
        public int ID { get; set; }

        public int PersonNr { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Fees { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }

    }
}
