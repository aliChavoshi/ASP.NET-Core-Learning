using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspLearning.Entities;

public class Author
{
    [Key] public int Id { get; set; }

    [Range(10, 80, ErrorMessage = "")]
    public int Age { get; set; } //10:80

    [InverseProperty("Author")] public List<Course> Courses { get; set; }
}