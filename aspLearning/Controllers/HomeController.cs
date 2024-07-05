using aspLearning.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using aspLearning.Entities;
using aspLearning.Interfaces;

namespace aspLearning.Controllers;

public class HomeController(IUnitOfWork uow)
    : Controller
{
    public IActionResult Index()
    {
        var course = new Course();
        uow.Courses.Add(course); // ?
        uow.Courses.SaveChanges();

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