using LibraryData;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryService
{
    public class LibraryCheckoutService : ICheckout
    {
        private readonly LibraryContext _context;

        public LibraryCheckoutService(LibraryContext context)
        {
            _context = context;
        }


    }
}
