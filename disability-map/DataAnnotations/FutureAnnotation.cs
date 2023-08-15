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
                //DateTime valueTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((long)value).ToLocalTime();
                

                if((long)value < DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds())
                {
                    return new ValidationResult("Time to reservation is to short or it is in the past");
                }
            }
            
            return ValidationResult.Success;
        }
    }
}
