using com.gaurav.domain.models;
using com.gaurav.main.infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace statementParser_WebApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly BloggingContext _db;

        public AuthorController(ILogger<AuthorController> logger, BloggingContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var authors = _db.Authors.ToList();
            return View(authors);
        }

        public IActionResult Upsert(int? id)
        {
           Author? author = new();
            if (id != null || id == 0)
            {
                author = _db.Authors.Find(id);
                if (author == null)
                    return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Author author)
        {
            ModelState.Remove("Books");
            if (ModelState.IsValid)
            {
                if (author.Author_Id == 0)
                {
                    await _db.Authors.AddAsync(author);
                }
                else
                {
                    _db.Authors.Update(author);
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
            return View(author);
        }

         public async Task<IActionResult> Delete(int id)
        {
            var author = _db.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            _db.Authors.Remove(author);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}