using System;

namespace BibliotekGruppProjekt.Models.Loan
{
    public class LoanDetailModel
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public string BookTitle { get; set; }
        public string MemberName { get; set; }
        public DateTime Checkout { get; set; }
        public DateTime? Returned { get; set; }
        public string TimeSpan { get; set; }
    }
}
