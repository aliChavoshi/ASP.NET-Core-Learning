using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace MyController.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    [Route("Index")]
    public ContentResult Index()
    {
        //Result , New
        // return new ContentResult()
        // {
        //       ContentType = "text/plain",
        //       StatusCode = 200,
        //       Content = "This in Index View"
        // };
        return Content("<p>this in content</p>", "text/html", Encoding.UTF8);
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