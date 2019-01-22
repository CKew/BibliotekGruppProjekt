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
        Loan GetFromMemberId(int? memberId);

        void AddLoan(Loan loan);
        void ReturnLoan(int Id);

        Loan GetFromId(int Id);

        string GetMemberName(int Id);
        string GetBookTitle(int Id);

    }
}
