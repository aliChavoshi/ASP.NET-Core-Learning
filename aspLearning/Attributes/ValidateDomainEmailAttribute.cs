using System.ComponentModel.DataAnnotations;

namespace aspLearning.Attributes;

//alichavoshi@gmail.com
public class ValidateDomainEmailAttribute(string allowDomain, string errorMessage = "...") : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var split = value?.ToString()!.Split("@"); // 0=> alichavoshi | 1 => gmail.com
        return string.Equals(split![1], allowDomain, StringComparison.CurrentCultureIgnoreCase); //true | false
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var split = value?.ToString()!.Split("@"); // 0=> alichavoshi | 1 => gmail.com
        var result = string.Equals(split![1], allowDomain, StringComparison.CurrentCultureIgnoreCase);
        if (result) return ValidationResult.Success;
        return new ValidationResult(string.Format(errorMessage ?? "please enter value"));
    }
}