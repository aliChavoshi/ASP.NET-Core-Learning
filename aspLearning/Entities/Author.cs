using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspLearning.Entities;

public class Author
{
    [Key] public int Id { get; set; }

    [Range(10, 80, ErrorMessage = "")]
    [Display(Name = "سن")] // asp-for="age"
    [DefaultValue(10)]
    public int Age { get; set; } = 10; //10:80

    [EmailAddress(ErrorMessage = "")] public string Email { get; set; }

    [DataType(DataType.DateTime)] public DateTime DateOfBirth { get; set; }

    [InverseProperty("Author")] public List<Course> Courses { get; set; }
}