using aspLearning.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using aspLearning.Context;
using aspLearning.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Controllers;

public class HomeController(MyContext context) : Controller
{
    public IActionResult Index()
    {
        var books = context.Books.Where(x => x.Level >= 1).ToList();
        return View();
    }

    public bool HandleLevel(Book book)
    {
        return book.Level > 1;
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