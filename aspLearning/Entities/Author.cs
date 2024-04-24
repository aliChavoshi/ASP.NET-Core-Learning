using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspLearning.Entities;

public class Author
{
    [Key] public int Id { get; set; }

    #region Relations

    public List<Course> Courses { get; set; }

    #endregion
}