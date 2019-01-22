using LibraryData;
using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryService
{
    public class FeeService : IFeeService
    {
        private readonly LibraryContext _context;

        public FeeService(LibraryContext context)
        {
            _context = context;
        }

        // Checks how many days the book has been loaned and if the book has been delayed
        public TimeSpan DaysLoaned(int id)
        {
            var loan = _context.Loans.FirstOrDefault(x => x.ID == id);

            var checkoutDate = loan.Checkout;

            DateTime delayedDate = checkoutDate.AddDays(14);

            if ((delayedDate - checkoutDate).TotalDays == 14)
            {
                loan.Delayed = true;

                // iterates through each day that the book has been delayed.
                if ((DateTime.Now - checkoutDate).TotalDays > 14 && loan.Returned == null)
                {
                    double fee = ((DateTime.Now - checkoutDate).TotalDays - 14) * 12;
                    loan.Fees = Convert.ToInt32(fee);
                    _context.SaveChanges();
                }

            }

            return (DateTime.Now - checkoutDate);
        }

    }
}
