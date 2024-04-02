using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Entities;
//SOLID => data annotation => S 
[Table("MyCourse", Schema = "catalog")]
[PrimaryKey(nameof(Id), nameof(Guid))]
public class Course(int id, string name, string description)
{
    [Key] //indexable
    // [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; } = id; //1 , 2 , 3

    [Key] public Guid Guid { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = name;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RecordNum { get; set; }

    public string Description { get; set; } = description;

    public List<string> Tags { get; set; } = new();

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)] //added or updated
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}