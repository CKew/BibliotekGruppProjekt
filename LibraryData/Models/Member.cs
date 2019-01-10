using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class Member
    {
        public int ID { get; set; }

        [Required]
        public int PersonNr { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0,int.MaxValue)]
        public IEnumerable<Loan> Loans { get; set; }

    }
}
