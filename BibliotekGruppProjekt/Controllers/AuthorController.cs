using BibliotekGruppProjekt.Models.Author;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        // Retrieves all the authors and returns them to the view
        public IActionResult Index()
        {
            var model = new AuthorIndexModel();
            model.Authors = _authorService.GetAll();

            return View(model);
        }

        // Gets information from specific author and returns it to the view
        public IActionResult Detail(int Id)
        {
            var model = new AuthorDetailModel();

            var author = _authorService.GetFromId(Id);

            model.ID = Id;
            model.Books = _authorService.GetAllBooksFromAuthor(Id);
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
            var author = _authorService.GetFromId(id);
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
