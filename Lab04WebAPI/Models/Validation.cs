using System.ComponentModel.DataAnnotations;

namespace Lab04WebAPI.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class GreaterThanZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is double && (double)value > 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The value must be greater than 0.");
        }
    }
}
