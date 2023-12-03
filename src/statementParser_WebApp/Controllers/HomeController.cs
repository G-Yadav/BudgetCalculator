using System.Diagnostics;
using com.gaurav.domain.models;
using com.gaurav.main.infrastructure;
using Microsoft.AspNetCore.Mvc;
using statementParser_WebApp.Models;

namespace statementParser_WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BloggingContext _db;

    public HomeController(ILogger<HomeController> logger, BloggingContext db)
    {
        _logger = logger;        
        _db = db;
    }

    public IActionResult Index()
    {
        var exists = _db.Categories.FirstOrDefault(x=>x.GenreName == "Romance");
        if(exists == null) {
            _db.Categories.Add(new Category {GenreName="Romance"});
            _db.SaveChanges();
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
