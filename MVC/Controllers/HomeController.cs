using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;
using Microsoft.Extensions.Options;
using MVC.Options;

namespace MVC.Controllers;

public class HomeController(
    ILogger<HomeController> logger,
    IWebHostEnvironment environment,
    IConfiguration configuration,
    IOptions<WeatherApiOptions> weatherOptions) : Controller
{
    private readonly WeatherApiOptions _options = weatherOptions.Value;

    public IActionResult Index()
    {
        //1
        // var weatherApi = configuration
        //     .GetSection("WeatherApi") //get parent
        //     .Get<WeatherApiOptions>(); //get children
        //
        // ViewBag.secretKey = weatherApi!.SecretKey!;
        // ViewBag.clientId = weatherApi.ClientId!;

        //2
        // var options = new WeatherApiOptions();
        // configuration.GetSection("WeatherApi")
        //     .Bind(options);

        ViewBag.secretKey = _options!.SecretKey!;
        ViewBag.clientId = _options.ClientId!;

        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult MyView()
    {
        var model = GetCountries();
        return PartialView("_PartialView", model);
    }

    private static CountryViewModel GetCountries()
    {
        //SOLID => S 
        var model = new CountryViewModel()
        {
            Names =
            [
                "Paris",
                "Kashan",
                "Tehran",
                "Karaj",
                "Ahvaz"
            ],
            Title = "Countries"
        };
        return model;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}