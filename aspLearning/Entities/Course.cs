using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Entities;

[Table("MyCourse", Schema = "catalog")]
[PrimaryKey(nameof(Id), nameof(Guid))]
public class Course(int id, string name, string description)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int Id { get; set; } = id;

    [Key] public Guid Guid { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = name;

    [Required(ErrorMessage = "please insert the value")]
    public string Description { get; set; } = description;

    public List<string> Tags { get; set; } = new();
}