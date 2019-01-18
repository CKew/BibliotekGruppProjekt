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
        private readonly ILoan _loanService;
        private readonly IBookCopy _bookCopyService;
        private readonly IMember _memberService;

        public LoanController(ILoan loans, IBookCopy bookCopyService, IMember memberService)
        {
            _loanService = loans;
            _bookCopyService = bookCopyService;
            _memberService = memberService;
        }
        // Gets all the loans and returns it
        //public IActionResult Index()
        //{
        //    var allLoans = _loanService.GetAll();

        //    var model = new LoanIndexModel();
        //    model.Loans = allLoans;

        //    return View(model);
        //}

        //// Retrieves a loan of a specific member and returns it
        //public IActionResult Detail(int ID)
        //{
        //    var member = _loanService.GetMember(ID);

        //    var model = new LoanDetailModel();

        //    model.ID = member.ID;
        //    model.Member = member;
            

        //    return View(model);
        //}

    }
}
