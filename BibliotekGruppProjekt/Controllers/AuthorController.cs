using BibliotekGruppProjekt.Models.Author;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthor _authorService;

        public AuthorController(IAuthor author)
        {
            _authorService = author;
        }

        public IActionResult Index()
        {
            var model = new AuthorIndexModel();
            model.Authors = _authorService.GetAll();

            return View(model);
        }

        public IActionResult Detail(int Id)
        {
            var model = new AuthorDetailModel();

            var author = _authorService.GetFromId(Id);

            model.ID = Id;
            model.Books = _authorService.GetAllBooksFromAuthor(Id);
            model.Name = author.Name;

            return View(model);
        }

    }
}
