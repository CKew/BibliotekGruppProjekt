using System.Collections.Generic;


namespace BibliotekGruppProjekt.Models.Member
{
    public class MemberDetailModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PersonNr { get; set; }
        public decimal OverdueFees { get; set; }
        public IEnumerable<LibraryData.Models.Loan> Loans { get; set; }
    }
}
