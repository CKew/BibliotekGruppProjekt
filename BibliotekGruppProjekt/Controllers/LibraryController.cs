using BibliotekGruppProjekt.Models.Library;
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
    public class LibraryController : Controller
    {
        private readonly IBook _bookService;
        private readonly IAuthor _authorService;

        public LibraryController(IBook bookService, IAuthor authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            var model = new LibraryIndexModel() { };
            var allBooks = _bookService.GetAll();

            model.Books = allBooks;



            return View(model);
        }


        public IActionResult Available()
        {
            var model = new LibraryIndexModel();

            model.Books = _bookService.GetAvailable();

            return View(model);
        }
        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _bookService.AddBook(book);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(book);
        //}

        //public IActionResult Edit(int id)
        //{
        //    var book = _bookService.GetBook(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(book);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int id, Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _bookService.Update(book);
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (_bookService.BookExists(book.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //    }
        //    return View(book);
        //}

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var book = _bookService.GetBook(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(book);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    _bookService.Delete(id);
        //    return RedirectToAction(nameof(Index));
        //}

        //// Author

        //public IActionResult FilterOnAuthor(BookIndexModel model)
        //{
        //    model.Authors = _authorService.GetSelectListItems();    

        //    return View("index", model);

        //}

        //public IActionResult Create()
        //{
        //    ViewBag.Authors = _authorService.GetSelectListItems();
        //    return View();
        //}


    }
}
