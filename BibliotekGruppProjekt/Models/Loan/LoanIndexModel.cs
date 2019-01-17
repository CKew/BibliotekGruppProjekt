using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Models.LoanCatalog
{
    public class LoanIndexModel
    {
        public IEnumerable<Loan> Loans { get; set; }
    }
}
