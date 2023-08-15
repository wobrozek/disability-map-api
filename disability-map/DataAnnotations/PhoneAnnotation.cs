using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace disability_map.DataAnnotations
{
    public class PhoneAnnotation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var match = Regex.Match((string)value, @"^([0-9]{2})?[0-9]{9}$");
                if (!match.Success)
                {
                    return new ValidationResult("wrong phone format");
                }
            }        
            return ValidationResult.Success;
        }
        
    }
}
