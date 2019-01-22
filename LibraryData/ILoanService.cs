using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryData
{
    public interface ILoanService
    {
        IQueryable<Loan> GetAll();
        Loan GetFromMemberId(int? memberID);

        void AddLoan(Loan loan);
        void ReturnLoan(int id);

        Loan GetFromId(int id);

        string GetMemberName(int id);
        string GetBookTitle(int id);

    }
}
