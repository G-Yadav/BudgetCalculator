using com.gaurav.domain.models;
using com.gaurav.main.infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using statementParser_WebApp.Models;

namespace statementParser_WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly BloggingContext _db;

        public BookController(ILogger<BookController> logger, BloggingContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var books = _db.Books.Include(x=>x.Publisher).ToList();
            return View(books);
        }

        public IActionResult Upsert(int? id)
        {
            BookVM? book = new();
            book.Book = new();
            if (id != null || id == 0)
            {
                book.Book = _db.Books.Find(id);
                if (book.Book == null)
                    return NotFound();
            }
            book.PublisherList = _db.Publishers.Select(x=> new SelectListItem() {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM bookVM)
        {
            ModelState.Remove("PublisherList");
            ModelState.Remove("Book.Authors");
            ModelState.Remove("Book.Publisher");
            ModelState.Remove("Book.BookDetail");
            if (ModelState.IsValid)
            {
                if (bookVM.Book.BookId == 0)
                {
                    await _db.Books.AddAsync(bookVM.Book);
                }
                else
                {
                    _db.Books.Update(bookVM.Book);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = ModelState
                            .Where(x => x.Value.Errors.Count > 0)
                            .Select(x => new { x.Key, x.Value.Errors })
                            .ToArray();
                            foreach(var error in errors) {
                                _logger.LogInformation($"{error.Key} {error.Errors}");
                            }
            }
            return View(bookVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id) 
        {
            if (id == null || id == 0)
                return NotFound();
            BookDetail bookDetail = new();

            bookDetail = await _db.BookDetails.Include(x => x.Book).FirstOrDefaultAsync(x => x.Book_Id == id);
            if (bookDetail == null)
            {
                return NotFound();
            }
            return View(bookDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookDetail bookDetail) 
        {
            if(bookDetail.BookDetail_Id == 0) 
            {
                await _db.BookDetails.AddAsync(bookDetail);
            }
            else
            {
                _db.BookDetails.Update(bookDetail);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult PlayGround() 
        {
            var bookTemp = _db.Books.FirstOrDefault();
            bookTemp.Price = 100;

            var bookCollection = _db.Books;
            decimal totalPrice = 0;

            foreach (var book in bookCollection)
            {
                totalPrice += book.Price;
            }

            var bookList = _db.Books.ToList();
            foreach (var book in bookList)
            {
                totalPrice += book.Price;
            }

            var bookCollection2 = _db.Books;
            var bookCount1 = bookCollection2.Count();

            var bookCount2 = _db.Books.Count();
            return RedirectToAction(nameof(Index));
        }
    }
}