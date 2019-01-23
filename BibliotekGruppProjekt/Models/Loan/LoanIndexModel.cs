using System.Linq;

namespace BibliotekGruppProjekt.Models.Loan
{
    public class LoanIndexModel
    {
        public IQueryable<LibraryData.Models.Loan> Loans { get; set; }
    }
}
