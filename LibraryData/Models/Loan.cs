using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryData.Models
{
    public class Loan
    {
        public int ID { get; set; }

        public DateTime Checkout { get; set; }

        public DateTime? Returned { get; set; }
        
        public int? Fees { get; set; }

        public bool Delayed { get; set; }

        [ForeignKey("BookCopy")]
        public int BookCopyId { get; set; }
        public virtual BookCopy BookCopy { get; set; }

        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
    }
}
