using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspLearning.Entities;

public class Author
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }

    #region Relations

    // public virtual List<Course> Courses { get; set; } //select many

    #endregion
}