using aspLearning.Interfaces;

namespace aspLearning.Services;

public class RestaurantService(ITeaService teaService) : IRestaurantService
{
    public string GetTea()
    {
        return teaService.GetTea();
    }
}