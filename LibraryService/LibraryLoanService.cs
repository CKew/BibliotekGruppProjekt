using System;
using System.Collections.Generic;
using LibraryData;
using LibraryData.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LibraryService
{
    public class LibraryLoanService : ILoan
    {
        // A connection to the database
        private LibraryContext _context;

        public LibraryLoanService(LibraryContext context)
        {
            _context = context;
        }

        // Adds a loan
        public void AddLoan(Loan loan)
        {
            _context.Add(loan);
            _context.SaveChanges();

            DaysLoaned(DateTime.Now);
        }

        // Removes a loan
        public void RemoveLoan(int memberID, int loanID)
        {
            Member member = _context.Members.FirstOrDefault(m => m.ID == memberID);
            Loan loan = member.Loans.FirstOrDefault(l => l.ID == loanID);

            _context.Remove(loan);
            _context.SaveChanges();

        }

        // Shows all the loans from the library
        public IEnumerable<Loan> GetAll()
        {
            return _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Member);
        }

        // Shows all loans of a specified member
        public Member GetMember(int id)
        {
            // return _context.Members.FirstOrDefault(m => m.ID == id).Loans;
            Member member = _context.Members.FirstOrDefault(m => m.ID == id);

            return member;
        }

        // Checks how many days the book has been loaned and if the book has been delayed
        public TimeSpan DaysLoaned(DateTime startDate)
        {
            DateTime delayedDate = startDate.AddDays(14);

            if ((delayedDate-startDate).TotalDays < 0)
            {
                DelayedLoan(true);

                // iterates through each day that the book has been delayed.
                for (DateTime date = startDate; date.Date <= delayedDate.Date; date = date.AddDays(1))
                {
                    Fee();
                }

            }

            return (DateTime.Now - startDate);
        }

        // Checks if a loan is delayed
        public bool DelayedLoan(bool delayed)
        {
            return true;
        }

        // Adds a fee
        public int Fee()
        {
            return 12;
        }
    }
}
