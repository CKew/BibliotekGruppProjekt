using BibliotekGruppProjekt.Models.Loan;
using LibraryData;
using LibraryData.Models;
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
        private readonly ICheckout _checkoutService;

        public LoanController(ILoan loans, ICheckout checkoutService)
        {
            _loanService = loans;
            _checkoutService = checkoutService;
        }

        // Gets all the loans and returns it
        public IActionResult Index()
        {
            var allLoans = _loanService.GetAll();

            var model = new LoanIndexModel();
            model.Loans = allLoans;

            return View(model);
        }

        public IActionResult Detail(int Id)
        {
            var loan = _loanService.GetFromMemberId(Id);

            var model = new LoanDetailModel();
            model.ID = Id;
            model.BookTitle = _loanService.GetBookTitle(Id);
            model.MemberName = _loanService.GetMemberName(Id);
            model.Checkout = loan.Checkout;
            

            return View(model);

        }

        public IActionResult Remove(Loan loan)
        {
            return View();
        }

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
