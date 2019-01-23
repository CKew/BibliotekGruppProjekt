using LibraryData.Models;
using System.Linq;

namespace LibraryData
{
    public interface ILoanService
    {
        IQueryable<Loan> GetAll();
        Loan GetFromMemberID(int? memberID);
        IQueryable<Loan> GetLoansFromMemberID(int id);

        Loan GetFromID(int id);

        void AddLoan(Loan loan);
        void ReturnLoan(int id);

        string GetMemberName(int id);
        string GetBookTitle(int id);

    }
}
