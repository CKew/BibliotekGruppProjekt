using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface ILoan
    {
        IEnumerable<Loan> GetAll();
        Member GetMember(int id);
            
        void AddLoan(Loan loan);
        void RemoveLoan(int memberID , int loanID);
        
        TimeSpan DaysLoaned(DateTime startDate);
        int Fee();
        bool DelayedLoan(bool delayed);
    }
}
