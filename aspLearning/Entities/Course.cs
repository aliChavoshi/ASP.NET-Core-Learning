using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace aspLearning.Entities;

public class Course
{
    private string _course = "";
    [Key] [BindNever] public int Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")] //validators
    [MaxLength(200, ErrorMessage = "مقدار {0} نباید بیشتر از 200 کاراکتر باشد")]
    [MinLength(10, ErrorMessage = "min length is 10")]
    [StringLength(50, MinimumLength = 4, ErrorMessage = "مقدار {0} باید بین {3} تا {2} کاراکتر باشد")]
    [Range(0, 100, ErrorMessage = "مقدار {0} میتواند بین {1} تا {2} باشد ")]
    public string Title
    {
        get => _course;
        set => _course = value.Trim();
    }

    [ValidateNever] public int AuthorId { get; set; }

    [Display(Name = "My level")] public int Level { get; set; }

    public float FullPrice { get; set; } = 0;

    #region Relations

    public virtual Author Author { get; set; }

    #endregion
}