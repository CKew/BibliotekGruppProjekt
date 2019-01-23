using LibraryData;
using LibraryData.Models;
using System.Collections.Generic;
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

        // Getting all Members. Including Loans
        public IQueryable<Member> GetAll()
        {
            return _context.Members
                .Include(x => x.Loans);
        }

        // Gets a member from ID
        public Member GetFromID(int? id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        // Adds a member to the database. Sets fees to 0.
        public void AddMember(Member member)
        {
            member.Fees = 0;
            _context.Add(member);
            _context.SaveChanges();
        }

        // Deletes a member.
        public void Delete(int id)
        {
            var member = _context.Members.Find(id);
            _context.Members.Remove(member);
            _context.SaveChanges();
        }
       
        // Gets a member ID from a loan.
        public int GetIDFromLoan(Loan loan)
        {
            return _context.Members.FirstOrDefault(x => x.ID == loan.MemberID).ID;
        }
    }
}
