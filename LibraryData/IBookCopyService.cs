using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IBookCopyService
    {
        IEnumerable<BookCopy> GetCopies(int bookID);

        void AddBookCopy(int id);
    }
}
