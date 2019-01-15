using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BibliotekGruppProjekt.Models.Member
{
    public class MemberDetailModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PersonNr { get; set; }
        public decimal OverdueFees { get; set; }
        /*public IEnumerable<Checkout> AssetsCheckedOut { get; set; }
        public IEnumerable<CheckoutHistory> CheckoutHistory { get; set; }*/
        public IEnumerable<Loan> Loans { get; set; }

    }
}
