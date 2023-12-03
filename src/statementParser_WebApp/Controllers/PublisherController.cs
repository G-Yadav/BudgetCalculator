using com.gaurav.domain.models;
using com.gaurav.main.infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace statementParser_WebApp.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ILogger<PublisherController> _logger;
        private readonly BloggingContext _db;

        public PublisherController(ILogger<PublisherController> logger, BloggingContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var pubishers = _db.Publishers.ToList();
            return View(pubishers);
        }

        public IActionResult Upsert(int? id)
        {
            Publisher? publisher = new();
            if (id != null || id == 0)
            {
                publisher = _db.Publishers.Find(id);
                if (publisher == null)
                    return NotFound();
            }
            return View(publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher publisher)
        {
            ModelState.Remove("Books");
            if (ModelState.IsValid)
            {
                if (publisher.Id == 0)
                {
                    await _db.Publishers.AddAsync(publisher);
                }
                else
                {
                    _db.Publishers.Update(publisher);
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
            return View(publisher);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var publisher = _db.Publishers.Find(id);
            if (publisher == null)
            {
                return NotFound();
            }
            _db.Publishers.Remove(publisher);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}