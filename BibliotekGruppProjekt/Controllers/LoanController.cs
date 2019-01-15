using BibliotekGruppProjekt.Models.LoanCatalog;
using LibraryData;
using LibraryService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Controllers
{
    public class LoanController : Controller
    {
        private ILoan _loans;

        public LoanController(ILoan loans)
        {
            _loans = loans;
        }

        public IActionResult Index()
        {
            var allLoans = _loans.GetAll();

            var model = new LoanIndexModel();
            model.Loans = allLoans;

            return View(model);
        }

    }
}
