using LibraryData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Models.Loan
{
    public class LoanIndexModel
    {
        public IQueryable<LibraryData.Models.Loan> Loans { get; set; }
    }
}
