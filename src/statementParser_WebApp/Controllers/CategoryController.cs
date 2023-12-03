using com.gaurav.domain.models;
using com.gaurav.main.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace statementParser_WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly BloggingContext _db;

        public CategoryController(ILogger<CategoryController> logger, BloggingContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> obj = _db.Categories.ToList();
            return View(obj);
        }

        public IActionResult Upsert(int? id)
        {
            Category? category = new();
            if (id != null || id == 0)
            {
                category = _db.Categories.Find(id);
                if (category == null)
                    return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    await _db.Categories.AddAsync(category);
                }
                else
                {
                    _db.Categories.Update(category);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple2()
        {
            List<Category> categories = new()
            {
                new (){GenreName = Guid.NewGuid().ToString()},
                new (){GenreName = Guid.NewGuid().ToString()}
            };
            await _db.Categories.AddRangeAsync(categories);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateMultiple5()
        {
            List<Category> categories = new()
            {
                new (){GenreName = Guid.NewGuid().ToString()},
                new (){GenreName = Guid.NewGuid().ToString()},
                new (){GenreName = Guid.NewGuid().ToString()},
                new (){GenreName = Guid.NewGuid().ToString()},
                new (){GenreName = Guid.NewGuid().ToString()}
            };
            await _db.Categories.AddRangeAsync(categories);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple2()
        {
            IEnumerable<Category> categories = _db.Categories.OrderByDescending(x=>x.Id).Take(2).ToList();
            _db.Categories.RemoveRange(categories);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // Romance, Thriller, Horror, Health, Biography 
        public async Task<IActionResult> RemoveMultiple5() 
        {
            IEnumerable<Category> categories = _db.Categories.OrderByDescending(x=>x.Id).Take(5).ToList();
            _db.Categories.RemoveRange(categories);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}