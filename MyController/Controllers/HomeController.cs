using System.Text;
using Microsoft.AspNetCore.Mvc;
using MyController.Entities;

namespace MyController.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    [Route("Index")]
    public IActionResult Index()
    {
        //1. Virtual  : wwwroot : input
        return new VirtualFileResult("/sample.pdf", "application/pdf");
        return File("/sample.pdf", "application/pdf");
        //2. Physical : out of your project
        return new PhysicalFileResult(@"c:/myproject/aspnetcore/sample.pdf", "application/pdf");
        return PhysicalFile(@"c:/myproject/aspnetcore/sample.pdf", "application/pdf");
        //3. File Content Result : out
        byte[] bytes = System.IO.File.ReadAllBytes(@"c:/myproject/aspnetcore/sample.pdf");
        return new FileContentResult(bytes, "application/pdf");
    }

    [Route("about")]
    public string About()
    {
        return "About us";
    }

    [Route("contact")]
    public string Contact()
    {
        return "Contact with Us";
    }
}