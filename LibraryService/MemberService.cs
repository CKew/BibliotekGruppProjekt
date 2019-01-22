using LibraryData;
using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryService
{
    public class MemberService : IMemberService
    {
        private LibraryContext _context;

        public MemberService(LibraryContext context)
        {
            _context = context;
        }

        // Used in LoanController to get memberId
        public int GetIdFromLoan(Loan loan)
        {
            return _context.Members.FirstOrDefault(x => x.ID == loan.MemberID).ID;
        }

        // Eager loading loans
        public IQueryable<Member> GetAll()
        {
            return _context.Members
                .Include(x => x.Loans);
        }

        public Member GetFromId(int? id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        // Returns all the loans of a specified member.
        public IQueryable<Loan> GetLoansFromId(int memberID)
        {
            var member = GetAll().FirstOrDefault(x => x.ID == memberID);

            var memberLoans = _context.Loans.Where(x => x.Member == member)
                .Include(x => x.BookCopy.Book);

            return memberLoans;
        }

        // Adds a member to the database.
        public void AddMember(Member member)
        {
            member.Fees = 0;
            _context.Add(member);
            _context.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            return _context.Members.ToList().OrderBy(x => x.ID).Select(x =>
            new SelectListItem
            {
               Text = $"{x.Name}",
               Value = x.ID.ToString()
            });
        }

    }
}
