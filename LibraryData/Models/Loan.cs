using System;
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
        public int BookCopyID { get; set; }
        public virtual BookCopy BookCopy { get; set; }

        [ForeignKey("Member")]
        public int MemberID { get; set; }
        public virtual Member Member { get; set; }
    }
}
