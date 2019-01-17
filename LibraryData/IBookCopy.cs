using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IBookCopy
    {
        IEnumerable<BookCopy> GetAvailable();
        IEnumerable<BookCopy> GetCopies(int bookId);

        void AddBookCopy(int bookId);
    }
}
