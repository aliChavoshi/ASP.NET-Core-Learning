using MVC.Models;

namespace MVC.Interfaces;

public interface ICountryRepository
{
    CountryViewModel GetCountries();
}