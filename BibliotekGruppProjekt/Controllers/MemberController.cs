using BibliotekGruppProjekt.Models.Loan;
using BibliotekGruppProjekt.Models.Member;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Detail(int Id)
        {
            var model = new MemberDetailModel();
            var member = _memberService.GetFromId(Id);
            model.ID = Id;
            model.Loans = _memberService.GetLoansFromId(Id);
            model.Name = member.Name;
            model.PersonNr = member.PersonNr;
            
            //model.OverdueFees = member.OverdueFees;

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

    }
}
