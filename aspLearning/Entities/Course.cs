using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Entities;

[Table("MyCourse", Schema = "catalog")]
[Index(nameof(Name), nameof(RecordNum), IsUnique = true, Name = "Multiple_Index")]
public class Course(int id, string name, string description)
{
    [Key] public int Id { get; set; } = id; //1 , 2 , 3

    //[ForeignKey(nameof(Author))]
    public int? AuthorId { get; set; } //nullable

    [ForeignKey(nameof(AuthorId))]
    public Author Author { get; set; }

    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "")] //@^$(*#&$()#*%_(
    public string Name { get; set; } = name;

    public int RecordNum { get; set; }

    public string Description { get; set; } = description;

    public bool IsDeleted { get; set; } = false; //false => true

    public DateTime CreatedRow { get; set; }

    //[ConcurrencyCheck]
    public byte[] RowVersion { get; set; }
}