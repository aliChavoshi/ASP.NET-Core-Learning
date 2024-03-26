using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Entities;

[Table("MyCourse", Schema = "catalog")]
//[Index(nameof(Name), IsUnique = true)]
public class Course(int id, string name, string description)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;

    [Required(ErrorMessage = "please insert the value")]
    public string Description { get; set; } = description;

    public List<string> Tags { get; set; } = new();
}