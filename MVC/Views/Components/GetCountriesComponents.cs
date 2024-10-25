using Microsoft.AspNetCore.Mvc;
using MVC.Interfaces;
using MVC.Models;

namespace MVC.Views.Components;

public class GetCountriesComponents(ICountryRepository countryRepository) : ViewComponent
{
    public Task<IViewComponentResult> InvokeAsync()
    {
        return Task.FromResult<IViewComponentResult>(
            View("/Views/Components/CountriesComponent.cshtml", countryRepository.GetCountries())
        );
    }
}