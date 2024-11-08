using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;
using MVC.Options;

namespace MVC.Controllers;

public class HomeController(
    ILogger<HomeController> logger,
    IWebHostEnvironment environment,
    IConfiguration configuration) : Controller
{
    public IActionResult Index()
    {
        //1
        // var weatherApi = configuration
        //     .GetSection(nameof(WeatherApi)) //get parent
        //     .Get<WeatherApi>(); //get children
        //
        // ViewBag.secretKey = weatherApi!.SecretKey!;
        // ViewBag.clientId = weatherApi.ClientId!;

        //2
        var options = new WeatherApi();
        configuration.GetSection(nameof(WeatherApi))
            .Bind(options);

        ViewBag.secretKey = options!.SecretKey!;
        ViewBag.clientId = options.ClientId!;

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