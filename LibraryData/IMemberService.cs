using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace LibraryData
{
    public interface IMemberService
    {
        IQueryable<Member> GetAll();
        Member GetFromID(int? id);

        int GetIDFromLoan(Loan loan);
        void AddMember(Member member);
        void Delete(int id);
    }
}
