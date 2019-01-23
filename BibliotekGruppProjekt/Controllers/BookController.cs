using BibliotekGruppProjekt.Models.Books;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BibliotekGruppProjekt.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IBookCopyService _bookCopyService;

        public BookController(IBookService bookService, IAuthorService authorService, IBookCopyService bookCopyService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _bookCopyService = bookCopyService;
        }

        // Retrieves all the books and returns them to the view
        public IActionResult Index()
        {
            var model = new BookIndexModel() { };
            var allBooks = _bookService.GetAll();

            model.Books = allBooks;

            return View(model);
        }

        // Gets all the available books
        public IActionResult Available()
        {
            var model = new BookIndexModel();

            model.Books = _bookService.GetAvailable();

            return View(model);
        }

        // Gets information from a specific book and returns it to the view
        public IActionResult Detail(int id)
        {
            var model = new BookDetailModel();

            var book = _bookService.GetFromID(id);
            model.ID = id;
            model.Title = book.Title;
            model.ISBN = book.ISBN;
            model.Description = book.Description;
            model.AuthorName = book.Author.Name;
            model.BookCopies = _bookCopyService.GetAllBookCopiesFromBookID(id);
            model.AvailableBookCopies = _bookCopyService.GetAllAvailableBookCopiesFromBookID(id);

            return View(model);
        }

        // Dropdown list of authors
        public IActionResult Create()
        {
            ViewBag.Authors = new SelectList(_authorService.GetAll(), "ID", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            ViewBag.Authors = new SelectList(_authorService.GetAll(), "ID", "Name");

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

            var book = _bookService.GetFromID(id);
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

        public IActionResult AddBookCopy(int id)
        {
            _bookCopyService.AddBookCopy(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
