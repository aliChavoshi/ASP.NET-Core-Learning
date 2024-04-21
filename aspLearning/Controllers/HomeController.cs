using aspLearning.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using aspLearning.Context;
using aspLearning.Entities;

namespace aspLearning.Controllers
{
    public class HomeController(ILogger<HomeController> logger, MyContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly MyContext _context = context;

        public IActionResult Index()
        {
            // _context.Courses.Add(new Course
            // {
            //     CreatedDate = 
            // })
            // _context.Courses.Add(new Course()
            // {
            //     Name = ""
            // });
            _context.SaveChanges();
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

        [HttpPost]
        public bool CheckingUserName(string username)
        {
            return false;
        }
    }
}