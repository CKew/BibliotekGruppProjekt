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
        private readonly IMember _memberService;
        private readonly ILoan _loanService;

        public MemberController(IMember member, ILoan loanService)
        {
            _memberService = member;
            _loanService = loanService;
        }

        public IActionResult Index()
        {
            var model = new MemberIndexModel();

            model.Members = _memberService.GetAll();

            return View(model);
        }

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


    }
}
