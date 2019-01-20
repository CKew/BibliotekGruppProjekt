using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryData
{
    public interface IMember
    {

        IQueryable<Member> GetAll();
        IQueryable<Loan> GetLoansFromId(int memberId);

        Member GetFromId(int Id);

        void AddMember(Member member);
    }
}
