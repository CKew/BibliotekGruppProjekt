using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IMember
    {
        Member GetMember(int id);
        IEnumerable<Member> GetAll();
        void Add(Member newMember);

        //IEnumerable<CheckoutHistory> GetCheckoutHistory(int memberId);
        //IEnumerable<Loan> GetLoan(int memberId);
        //IEnumerable<CheckoutHistory> GetCheckouts(int memberId);
    }
}
