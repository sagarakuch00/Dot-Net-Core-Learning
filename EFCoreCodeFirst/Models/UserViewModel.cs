using EFCoreCodeFirst.Custom_validations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Name can have 2 to 10 characters long")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Choose user name")]
        [MinLength(2, ErrorMessage = "Username should be more than 2 characters")]
        [MaxLength(20, ErrorMessage = "Username should not contain more than 20 characters")]
        [UsernameValidationAttribute]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter age")]
        [Range(1, 120, ErrorMessage = "Age shuld be between 1 to 120")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        //[RegularExpression("", ErrorMessage ="Invalid Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        //[RegularExpression("", ErrorMessage ="Weak Password")]
        [DataType(DataType.Password, ErrorMessage = "Very Weak Password")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please Confirm Password again")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password shuld be same")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please Enter Your Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        [DateValidation]
        public DateTime DateOfBirth { get; set; }
    }
}
