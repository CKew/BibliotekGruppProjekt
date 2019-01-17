using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Loan
    {
        public int ID { get; set; }

        public DateTime Checkout { get; set; }

        public DateTime? Returned { get; set; }

        public BookCopy BookCopy { get; set; }

        public Member Member { get; set; }
    }
}
