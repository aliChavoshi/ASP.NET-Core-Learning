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
        //Explicit loading
        //proxy => 1
        //1
        var author = context.Author.SingleOrDefault(x => x.Id == 1);
        context.Entry(author!).Collection(c => c.Courses)
            .Query().Where(c => c.Level > 2).Load();

        //2
        context.Courses.Where(x => x.AuthorId == author!.Id && x.Level > 2).Load();

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