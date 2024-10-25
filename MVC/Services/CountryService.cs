using MVC.Interfaces;
using MVC.Models;

namespace MVC.Services;

public class CountryService : ICountryRepository
{
    public CountryViewModel GetCountries()
    {
        //SOLID =>  
        return new CountryViewModel()
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
    }
}