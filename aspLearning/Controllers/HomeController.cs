using aspLearning.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aspLearning.Controllers;

public class HomeController : Controller
{
    //Request => client => server 
    //Response  => server => client
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

    //MVC
    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Client, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}