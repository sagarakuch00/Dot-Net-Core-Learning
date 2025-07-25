using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.Custom_validations
{
    public class DateValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime inputDate = (DateTime) value;

            if (inputDate > DateTime.Now)
            {
                return new ValidationResult("Date of Birth is can not be grater than today's date");
            }
            return ValidationResult.Success;
        }
    }
}
