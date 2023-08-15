using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace disability_map.DataAnnotations
{
    public class FutureAnnotation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is not null)
            {
                DateTime valueTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((int)value).ToLocalTime();

                if(valueTime > DateTime.UtcNow)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Data must be in the future");
                }
            }
            
            return ValidationResult.Success;
        }
    }
}
