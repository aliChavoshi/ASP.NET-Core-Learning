using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    public IActionResult Index()
    {
        return View("Index");
    }

    public IActionResult Privacy()
    {
        ViewData["CountryTitle"] = "Countries";
        ViewData["Countries"] = new List<string>()
        {
            "Paris",
            "Kashan",
            "Tehran",
            "Karaj"
        };
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}