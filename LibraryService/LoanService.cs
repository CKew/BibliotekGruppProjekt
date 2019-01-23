using System;
using LibraryData;
using LibraryData.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        // Returns all the loans. Includes BookCopy.Book and Member
        public IQueryable<Loan> GetAll()
        {
            return _context.Loans
                .Include(x => x.BookCopy.Book)
                .Include(x => x.Member);
        }
 
        // Gets a loan from its ID
        public Loan GetFromID(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        // Adds a new loan. Sets the Datetime to Now and sets the bookcopy status to true.
        public void AddLoan(Loan loan)
        {
            var _bookCopyService = new BookCopyService(_context);

            loan.Checkout = DateTime.Now;
            _context.Add(loan);
            _bookCopyService.SetStatusToTrue(loan);
            _context.SaveChanges();
        }

        // Returns all the loans from a member.
        public Loan GetFromMemberID(int? id)
        {
            var member = _context.Members.FirstOrDefault(x => x.ID == id);

            return GetAll().FirstOrDefault(x => x.Member == member);

        }
        
        // Returns a loan. Sets the return date to Datetime.Now. Sets the fees to the member Fees Property. Sets the bookCopy.Status to false.
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

        // Gets the books title from a loan. (Used in LoanController > DetailModel)
        public string GetBookTitle(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id).BookCopy.Book.Title;
        }

        // Gets the member Name from a loan. (Used in LoanController > DetailModel)
        public string GetMemberName(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id).Member.Name;
        }

        // Returns all the loans of a specified member. Includes Book
        public IQueryable<Loan> GetLoansFromMemberID(int id)
        {
            var member = _context.Members.FirstOrDefault(x => x.ID == id);

            return GetAll().Where(x => x.Member == member)
                .Include(x => x.BookCopy.Book);

        }
    }
}
