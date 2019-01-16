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
    }
}
