using System;
using System.Collections.Generic;
using LibraryData;
using LibraryData.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        // Adds a new loan with a member and bookCopy attatched to it to the Database. Also sets the bookCopy.Status == true.
        public void AddLoan(Member member, BookCopy bookCopy)
        {

            var loan = new Loan() {
                Member = member,
                BookCopy = bookCopy
            };

            bookCopy.Status = true;

            _context.Add(loan);
            _context.SaveChanges();
        }

        // Returns all the loans.
        public IQueryable<Loan> GetAll()
        {
            return _context.Loans
                .Include(x => x.BookCopy.Book)
                .Include(x => x.Member);
        }



        // Returns all the loans from a specified member.
        public Loan GetFromMemberId(int memberId)
        {
            var member = _context.Members.FirstOrDefault(x => x.ID == memberId);

            return _context.Loans.FirstOrDefault(x => x.Member == member);

        }
        
        // Returns a loan from a specified member and book and removes it from the database. sets the bookCopy.Status == false;
        public void ReturnLoan(int memberId, int bookCopyId)
        {
            var member = _context.Members.FirstOrDefault(x => x.ID == memberId);
            var bookCopy = _context.BookCopies.FirstOrDefault(x => x.Id == bookCopyId);

            var loan = _context.Loans.FirstOrDefault(x => x.BookCopy == bookCopy && x.Member == member);

            bookCopy.Status = false;

            _context.Remove(loan);
            _context.SaveChanges();
        }

        public string GetBookTitle(int Id)
        {
            return GetAll().FirstOrDefault(x => x.ID == Id).BookCopy.Book.Title;
        }

        public string GetMemberName(int Id)
        {
            return GetAll().FirstOrDefault(x => x.ID == Id).Member.Name;
        }


        //// Checks how many days the book has been loaned and if the book has been delayed
        //public TimeSpan DaysLoaned(DateTime startDate)
        //{
        //    DateTime delayedDate = startDate.AddDays(14);

        //    if ((delayedDate-startDate).TotalDays < 0)
        //    {
        //        DelayedLoan(true);

        //        // iterates through each day that the book has been delayed.
        //        for (DateTime date = startDate; date.Date <= delayedDate.Date; date = date.AddDays(1))
        //        {
        //            Fee();
        //        }

        //    }

        //    return (DateTime.Now - startDate);
        //}

        //// Checks if a loan is delayed
        //public bool DelayedLoan(bool delayed)
        //{
        //    return true;
        //}

        //// Adds a fee
        //public int Fee()
        //{
        //    return 12;
        //}
    }
}
