using System.Text;
using Microsoft.AspNetCore.Mvc;
using MyController.Entities;

namespace MyController.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    [Route("Index/{pageId:int?}/{searchBy}")]
    //Query String : http://localhost:5183/Index?pageId=10&searchBy=AliChavoshi
    //Route Data : http://localhost:5183/index/10/alichavoshi
    //Mix : http://localhost:5183/index/10?searchBy=alichavoshi
    public IActionResult Index([FromRoute] int? pageId, [FromQuery] string? searchBy)
    {
        return Content($"pageId : {pageId} - searchBy : {searchBy}");
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