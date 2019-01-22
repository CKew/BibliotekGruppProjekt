using BibliotekGruppProjekt.Models.Loan;
using LibraryData;
using LibraryData.Models;
using LibraryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly IFeeService _feeService;
        private readonly IMemberService _memberService;
        private readonly IBookService _bookService;

        public LoanController(ILoanService loans, IFeeService feeService, IMemberService memberService, IBookService bookService)
        {
            _bookService = bookService;
            _memberService = memberService;
            _loanService = loans;
            _feeService = feeService;
        }

        // Gets all the loans and returns it
        public IActionResult Index()
        {
            var allLoans = _loanService.GetAll();

            

            var model = new LoanIndexModel();
            model.Loans = allLoans;

            return View(model);
        }

        // Details about a specific loan
        public IActionResult Detail(int Id)
        {
            var loan = _loanService.GetFromId(Id);

            var timeSinceLoaned = _feeService.DaysLoaned(Id);

            var model = new LoanDetailModel();
            model.ID = Id;
            model.BookTitle = _loanService.GetBookTitle(Id);
            model.MemberName = _loanService.GetMemberName(Id);
            model.Checkout = loan.Checkout;
            model.Returned = loan.Returned;
            model.MemberId = _memberService.GetIdFromLoan(loan);
            model.TimeSpan = timeSinceLoaned.ToString("%d");
            

            return View(model);

        }
        // Dropdown menu of members and bookcopies
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Members = _memberService.GetSelectListItems();
            ViewBag.BookCopies = new SelectList(_bookService.GetAvailableCopies(), "Id", "Book.Title");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Loan loan)
        {
            if (ModelState.IsValid)
            {
                _loanService.AddLoan(loan);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

        // Returns the loan
        public IActionResult Return(int Id)
        {
            if (ModelState.IsValid)
            {
                _loanService.ReturnLoan(Id);

                var model = new LoanIndexModel();
                model.Loans = _loanService.GetAll();

                return View("Index", model);

            }
            else
            {
                return NotFound();
            }
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var loan = _loanService.GetFromMemberId(id);
            if (loan == null)
            {
                return NotFound();
            }
            return View(loan);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            return View();
        }
    }
}
