using System.ComponentModel.DataAnnotations;
using CRUDUsingEFCoreCodeFirst.Models;

namespace EFCoreCodeFirst.Custom_validations
{
    public class UsernameValidationAttribute : ValidationAttribute
    {
       
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var dbContext = (ProductDbContext)validationContext.GetService(typeof(ProductDbContext));

            bool usernameExist = dbContext.Users.Any(c => c.UserName == value.ToString());
            if (usernameExist)
            {
                return new ValidationResult("Username already taken");
            }
            return ValidationResult.Success;
        }
    }
}
