using Microsoft.AspNetCore.Mvc;

namespace MVC.Views.Components;

public class GetCountriesComponents : ViewComponent
{
    public Task<IViewComponentResult> InvokeAsync()
    {
        //Logic
        return Task.FromResult<IViewComponentResult>(
            View("/Views/Components/CountriesComponent.cshtml", "asp .net core from ALI")
        );
    }
}