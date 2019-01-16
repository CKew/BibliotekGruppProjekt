﻿using BibliotekGruppProjekt.Models.LoanCatalog;
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
        private ILoan _loanService;

        public LoanController(ILoan loans)
        {
            _loanService = loans;
        }

        public IActionResult Index()
        {
            var allLoans = _loanService.GetAll();

            var model = new LoanIndexModel();
            model.Loans = allLoans;

            return View(model);
        }

        public IActionResult Detail(int ID)
        {
            var member = _loanService.GetMember(ID);

            var model = new LoanDetailModel();

            model.ID = member.ID;
            model.Member = member;
            

            return View(model);
        }

    }
}
