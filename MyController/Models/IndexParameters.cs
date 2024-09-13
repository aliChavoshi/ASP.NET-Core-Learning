using Microsoft.AspNetCore.Mvc;

namespace MyController.Models;

public class IndexParameters
{
    [FromQuery] public int? PageId { get; set; } = 10;
    [FromRoute] public string? SearchBy { get; set; }
}