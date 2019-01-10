using Microsoft.EntityFrameworkCore;
using LibraryData.Models;
    
namespace LibraryData
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
