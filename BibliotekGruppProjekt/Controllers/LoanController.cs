using BibliotekGruppProjekt.Models.Loan;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult Detail(int id)
        {
            var loan = _loanService.GetFromID(id);

            var timeSinceLoaned = _feeService.DaysLoaned(id);

            var model = new LoanDetailModel();
            model.ID = id;
            model.BookTitle = _loanService.GetBookTitle(id);
            model.MemberName = _loanService.GetMemberName(id);
            model.Checkout = loan.Checkout;
            model.Returned = loan.Returned;
            model.MemberID = _memberService.GetIDFromLoan(loan);
            model.TimeSpan = timeSinceLoaned.ToString("%d");

            return View(model);

        }

        // Dropdown menu of members and bookcopies
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Members = new SelectList(_memberService.GetAll(), "ID", "Name"); 
            ViewBag.BookCopies = new SelectList(_bookService.GetAvailableCopies(), "ID", "Book.Title");
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
        public IActionResult Return(int id)
        {
            if (ModelState.IsValid)
            {
                _loanService.ReturnLoan(id);

                var model = new LoanIndexModel();
                model.Loans = _loanService.GetAll();

                return View("Index", model);

            }
            else
            {
                return NotFound();
            }
        }
    }
}
