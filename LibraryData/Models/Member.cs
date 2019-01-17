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

        public string Name { get; set; }

        public IEnumerable<Loan> Loans { get; set; }

    }
}
