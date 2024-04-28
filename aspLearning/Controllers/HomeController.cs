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
        var books = context.Books.ToList();
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