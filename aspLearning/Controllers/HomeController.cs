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
        var course = new Course()
        {
            AuthorId = 1,
            Level = 2,
            Title = "new Course"
        };
        var beforeAdd = context.Entry(course).State;
        context.Add(course);
        var afterAdded = context.Entry(course).State;
        context.SaveChanges();
        var afterSaveChanges = context.Entry(course).State;

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