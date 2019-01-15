using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Loan
    {
        public int ID { get; set; }

        [Required]
        public DateTime Checkout { get; set; }

        public DateTime? Returned { get; set; }

        [Required]
        public Book Book { get; set; }

        [Required]
        public Member Member { get; set; }
    }
}
