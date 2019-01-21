using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryData
{
    public interface ILoan
    {
        IQueryable<Loan> GetAll();
        Loan GetFromMemberId(int memberId);

        void AddLoan(Loan loan);
        void ReturnLoan(Loan loan);

        string GetMemberName(int Id);
        string GetBookTitle(int Id);

    }
}
