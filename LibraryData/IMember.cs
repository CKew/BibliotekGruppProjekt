using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IMember
    {
        // Gets the member by id
        Member GetMember(int id);
        // Lists all the members
        IEnumerable<Member> GetAll();
        // Adds the new member
        void Add(Member newMember);

        //IEnumerable<CheckoutHistory> GetCheckoutHistory(int memberId);
        //IEnumerable<Loan> GetLoan(int memberId);
        //IEnumerable<CheckoutHistory> GetCheckouts(int memberId);
    }
}
