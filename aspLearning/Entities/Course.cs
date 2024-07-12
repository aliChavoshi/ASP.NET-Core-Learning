using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Entities;

public class Course
{
    private string _course = "";
    [Key] public int Id { get; set; }

    [Display(Name = "Title")]
    // [Required(ErrorMessage = "Please insert value.")]
    public string Title
    {
        get => _course;
        set => _course = value.Trim();
    }

    public int AuthorId { get; set; }

    [Display(Name = "My level")] public int Level { get; set; }

    public float FullPrice { get; set; } = 0;

    #region Relations

    public virtual Author Author { get; set; }

    #endregion
}