using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Views.Components;

public class GetCountriesComponents : ViewComponent
{
    public Task<IViewComponentResult> InvokeAsync(CountryViewModel model)
    {
        //Logic
        return Task.FromResult<IViewComponentResult>(
            View("/Views/Components/CountriesComponent.cshtml", model)
        );
    }
}