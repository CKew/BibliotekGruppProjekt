using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IMember
    {
        IEnumerable<Loan> GetLoans(int memberId);

        void AddMember(Member member);
    }
}
