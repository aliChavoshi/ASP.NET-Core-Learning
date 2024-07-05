using aspLearning.Interfaces;

namespace aspLearning.Services;

public class TeaService : ITeaService
{
    private readonly int _randomId;

    private readonly Dictionary<int, string> _teaDictionary = new()
    {
        { 1, "Normal Tea ☕️" },
        { 2, "Lemon Tea ☕️" },
        { 3, "Green Tea ☕️" },
        { 4, "Masala Chai ☕️" },
        { 5, "Ginger Tea ☕️" }
    };

    public TeaService()
    {
        _randomId = new Random().Next(1, 5);
    }

    public string GetTea()
    {
        return _teaDictionary[_randomId];
    }
}