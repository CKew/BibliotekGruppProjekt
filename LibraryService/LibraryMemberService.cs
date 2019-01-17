using LibraryData;
using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryService
{
    public class LibraryMemberService : IMember
    {
        private LibraryContext _context;

        public LibraryMemberService(LibraryContext context)
        {
            _context = context;
        }

        // Returns all the loans of a specified member.
        public IEnumerable<Loan> GetLoans(int memberId)
        {
            var member = _context.Members.FirstOrDefault(x => x.ID == memberId);

            var memberLoans = _context.Loans.Where(x => x.Member == member);

            return memberLoans;
        }

        // Adds a member to the database.
        public void AddMember(Member member)
        {
            _context.Add(member);
            _context.SaveChanges();
        }

    }
}
