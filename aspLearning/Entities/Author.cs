using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using aspLearning.Attributes;
using Newtonsoft.Json.Linq;

namespace aspLearning.Entities;

public class Author : IValidatableObject
{
    [Key] public int Id { get; set; }

    public string Name { get; set; } 

    [ValidateDomainEmail("gmail.com", "please write gmail.com domain")]
    public string Email { get; set; }

    #region Relations

    // public virtual List<Course> Courses { get; set; } //select many

    #endregion

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var split = Email.Split("@"); // 0=> alichavoshi | 1 => gmail.com
        var result = string.Equals(split![1], "GMAIL.COM", StringComparison.CurrentCultureIgnoreCase);
        if (result) yield return new ValidationResult("please enter valid domain");
    }
}