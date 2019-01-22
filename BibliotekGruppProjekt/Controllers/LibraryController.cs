using BibliotekGruppProjekt.Models.Library;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IBookCopy _bookCopyService;

        public LibraryController(IBookService bookService, IAuthorService authorService, IBookCopy bookCopyService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _bookCopyService = bookCopyService;
        }

        // Retrieves all the books and returns them to the view
        public IActionResult Index()
        {
            var model = new LibraryIndexModel() { };
            var allBooks = _bookService.GetAll();

            model.Books = allBooks;

            return View(model);
        }

        // Gets all the available books
        public IActionResult Available()
        {
            var model = new LibraryIndexModel();

            model.Books = _bookService.GetAvailable();

            return View(model);
        }
        
        // Gets information from a specific book and returns it to the view
        public IActionResult Detail(int Id)
        {
            var model = new BookDetailModel();

            var book = _bookService.GetFromId(Id);
            model.ID = Id;
            model.Title = book.Title;
            model.ISBN = book.ISBN;
            model.Description = book.Description;
            model.AuthorName = book.Author.Name;
            model.BookCopies = _bookService.GetAllBookCopiesFromId(Id);
            model.AvailableBookCopies = _bookService.GetAllAvailableBookCopiesFromId(Id);

            return View(model);
        }

        // Dropdown list of authors
        public IActionResult Create()
        {
            ViewBag.Authors = _authorService.GetSelectListItems();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(book);

                return RedirectToAction(nameof(Index)); 
            }
            else
            {
                return View();
            }
        }

        // Gets the specific book to delete and returns seperate view
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetFromId(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Confirmation to delete specific book
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddBookCopy(int Id)
        {
            _bookCopyService.AddBookCopy(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
