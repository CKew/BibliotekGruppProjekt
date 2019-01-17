﻿using BibliotekGruppProjekt.Models.Member;
using LibraryData;
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

        // Gets all the members created and returns it
        //public IActionResult Index()
        //{
        //    var allMembers = _memberService.GetAll();

        //    //var memberModels = allMembers.Select(m => new MemberDetailModel
        //    //{
        //    //    ID = m.ID,
        //    //    Name = m.Name,
        //    //    PersonNr = m.PersonNr
        //    //    //Loans = m.Loans
        //    //    /*OverdueFees = m.?.Fees*/
        //    //}).ToList();

        //    var model = new MemberIndexModel();
        //    model.Members = allMembers;
        //    return View(model);

        //}

        //// Retrieves the specific member and returns information regarding that user
        //public IActionResult Detail(int ID)
        //{
        //    var member = _memberService.GetMember(ID);

        //    var model = new MemberDetailModel();

        //    model.ID = member.ID;
        //    model.Loans = member.Loans;
        //    model.Name = member.Name;
        //    model.PersonNr = member.PersonNr;

        //    return View(model);
        //}
    }
}
