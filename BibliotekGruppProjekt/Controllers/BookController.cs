using BibliotekGruppProjekt.Models.BookCatalog;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Controllers
{
    public class BookController : Controller
    {
        private IBook _bookService;

        public BookController(IBook bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var allBooks = _bookService.GetAll();

            var model = new BookIndexModel();

            model.Books = allBooks;

            return View(model);
        }

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
    }
}
