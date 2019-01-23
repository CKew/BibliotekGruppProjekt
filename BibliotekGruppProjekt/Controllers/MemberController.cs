using BibliotekGruppProjekt.Models.Member;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekGruppProjekt.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly ILoanService _loanService;

        public MemberController(IMemberService member, ILoanService loanService)
        {
            _memberService = member;
            _loanService = loanService;
        }

        // Gets all the members
        public IActionResult Index()
        {
            var model = new MemberIndexModel();

            model.Members = _memberService.GetAll();

            return View(model);
        }

        // Gets details from a specific member
        public IActionResult Detail(int id)
        {
            var model = new MemberDetailModel();
            var member = _memberService.GetFromID(id);
            model.ID = id;
            model.Loans = _loanService.GetLoansFromMemberID(id);
            model.Name = member.Name;
            model.PersonNr = member.PersonNr;

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member member)
        {
            if (ModelState.IsValid)
            {
                _memberService.AddMember(member);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // Gets the specific member to delete and returns seperate view
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _memberService.GetFromID(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Confirmation to delete specific member
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _memberService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
