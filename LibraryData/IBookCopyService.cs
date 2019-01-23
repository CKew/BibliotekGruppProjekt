using LibraryData.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryData
{
    public interface IBookCopyService
    {
        IEnumerable<BookCopy> GetCopies(int ID);
        IQueryable<BookCopy> GetAllBookCopiesFromBookID(int id);
        IQueryable<BookCopy> GetAllAvailableBookCopiesFromBookID(int id);


        void AddBookCopy(int ID);
    }
}
