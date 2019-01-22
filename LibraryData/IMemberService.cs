using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryData
{
    public interface IMemberService
    {

        IQueryable<Member> GetAll();
        IQueryable<Loan> GetLoansFromId(int memberId);
        IEnumerable<SelectListItem> GetSelectListItems();
        Member GetFromId(int? Id);
        int GetIdFromLoan(Loan loan);

        void AddMember(Member member);
    }
}
