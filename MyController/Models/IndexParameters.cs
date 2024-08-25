using Microsoft.AspNetCore.Mvc;

namespace MyController.Models;

public class IndexParameters
{
    [FromQuery] public int? PageId { get; set; } = 10;
    [FromQuery] public string? SearchBy { get; set; }
}