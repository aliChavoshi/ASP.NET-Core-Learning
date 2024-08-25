using Microsoft.AspNetCore.Mvc;

namespace MyController.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    [Route("Index")]
    public string Index()
    {
        return "Ali Chavoshi";
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