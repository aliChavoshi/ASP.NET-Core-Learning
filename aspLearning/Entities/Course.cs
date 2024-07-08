using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Entities;

public class Course
{
    [Key] public int Id { get; set; }

    [Display(Name = "Title")]
    public string Title { get; set; }

    public int AuthorId { get; set; }

    [Display(Name = "My level")]
    public int Level { get; set; }

    public float FullPrice { get; set; } = 0;

    #region Relations

    public virtual Author Author { get; set; }

    #endregion
}