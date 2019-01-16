using BibliotekGruppProjekt.Models.BookCatalog;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Controllers
{
    public class BookController : Controller
    {
        private IBook _bookService;
        private IAuthor _authorService;

        public BookController(IBook bookService, IAuthor authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        // Gets all the books and returns it
        public IActionResult Index()
        {
            var allBooks = _bookService.GetAll();
            var allAuthors = _authorService.GetSelectListItems();

            var model = new BookIndexModel();

            model.Books = allBooks;
            model.Authors = allAuthors;

            return View(model);
        }

        // Retrieves specific book and returns the information regarding it
        public IActionResult Detail(int Id)
        {
            var book = _bookService.GetBook(Id);

            var model = new BookDetailModel();

            model.Title = book.Title;
            model.Author = book.Author;
            model.Description = book.Description;
            model.ISBN = book.ISBN;

            return View(model);
        }

        public IActionResult Available()
        {
            var model = new BookIndexModel();
            model.Books = _bookService.GetAvailable();
            model.Authors = _authorService.GetSelectListItems();
            return View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _bookService.Update(book);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_bookService.BookExists(book.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(book);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // Author

        public IActionResult FilterOnAuthor(BookIndexModel model)
        {
            model.Authors = _bookService.GetFromAuthor(authorId);
            model.Authors = _authorService.GetSelectListItems();

            return View("index", model);

        }

        public IActionResult Create()
        {
            ViewBag.Authors = _authorService.GetSelectListItems();
            return View();
        }


    }
}
