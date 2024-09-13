using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using aspLearning.Attributes;

namespace aspLearning.Entities;

public class Author
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }

    [ValidateDomainEmail("gmail.com","please write gmail.com domain")]
    public string Email { get; set; }

    #region Relations

    // public virtual List<Course> Courses { get; set; } //select many

    #endregion
}