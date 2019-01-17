using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface ILoan
    {
        IEnumerable<Loan> GetAll();
        IEnumerable<Loan> GetFromMember(int memberId);
            
        void AddLoan(int memberId, int bookCopyId);
        void ReturnLoan(int memberID , int bookCopyId);

    }
}
