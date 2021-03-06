﻿using BibliotekGruppProjekt.Models.Author;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekGruppProjekt.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService author)
        {
            _authorService = author;
        }

        // Retrieves all the authors and returns them to the view
        public IActionResult Index()
        {
            var model = new AuthorIndexModel();
            model.Authors = _authorService.GetAll();

            return View(model);
        }

        // Gets information from specific author and returns it to the view
        public IActionResult Detail(int id)
        {
            var model = new AuthorDetailModel();

            var author = _authorService.GetFromID(id);

            model.ID = id;
            model.Books = _authorService.GetAllBooksFromAuthor(id);
            model.Name = author.Name;

            return View(model);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _authorService.AddAuthor(author);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // Gets the specific author to delete and returns seperate view
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var author = _authorService.GetFromID(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // Confirmation to delete the specific author
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _authorService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
