using System.Text;
using Microsoft.AspNetCore.Mvc;
using MyController.Entities;
using MyController.Models;

namespace MyController.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    [Route("Index")]
    //From Query
    public IActionResult Index(IndexParameters parameters)
    {
        return Content($"pageId : {parameters.PageId} - searchBy : {parameters.SearchBy}");
    }

    [Route("Test")]
    public IActionResult Test(int id)
    {
        return new BadRequestResult();
        return BadRequest(); //400

        return new NotFoundResult();
        return NotFound(); //404

        return new UnauthorizedResult();
        return Unauthorized(); //401

        return StatusCode(404, "Not Found");
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