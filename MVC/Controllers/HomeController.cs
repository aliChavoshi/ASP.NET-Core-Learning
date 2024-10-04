using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    //http://localhost:5122/Home/Index
    public IActionResult Index()
    {
        return View("Index"); //index.cshtml
        //return new ViewResult();
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