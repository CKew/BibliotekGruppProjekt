using System;
using System.Collections.Generic;
using LibraryData;
using LibraryData.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryService
{
    public class LoanService : ILoanService
    {
        // A connection to the database
        private LibraryContext _context;

        public LoanService(LibraryContext context)
        {
            _context = context;
        }

        // Adds a new loan with a member and bookCopy attatched to it to the Database. Also sets the bookCopy.Status == true.
        public void AddLoan(Loan loan)
        {
            var _bookCopyService = new BookCopyService(_context);

            loan.Checkout = DateTime.Now;
            _context.Add(loan);
            _bookCopyService.SetStatusToTrue(loan);
            _context.SaveChanges();
        }

        public Loan GetFromId(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        // Returns all the loans.
        public IQueryable<Loan> GetAll()
        {
            return _context.Loans
                .Include(x => x.BookCopy.Book)
                .Include(x => x.Member);
        }

        // Returns all the loans from a specified member.
        public Loan GetFromMemberId(int? memberID)
        {
            var member = _context.Members.FirstOrDefault(x => x.ID == memberID);

            return _context.Loans.FirstOrDefault(x => x.Member == member);

        }
        
        // Returns a loan from a specified member and book and removes it from the database. sets the bookCopy.Status == false;
        public void ReturnLoan(int id)
        {
            var loan = _context.Loans.FirstOrDefault(x => x.ID == id);
            loan.Returned = DateTime.Now;

            var member = _context.Members.FirstOrDefault(x => x.ID == loan.MemberID);

            member.Fees = loan.Fees + member.Fees;

            var _bookCopyService = new BookCopyService(_context);

            _bookCopyService.SetStatusToFalse(loan);
            _context.SaveChanges();
        }

        public string GetBookTitle(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id).BookCopy.Book.Title;
        }

        public string GetMemberName(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id).Member.Name;
        }







    }
}
