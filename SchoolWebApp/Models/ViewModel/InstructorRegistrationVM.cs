using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolWebApp.Models.ViewModel
{
    public class InstructorRegistrationVM
    {

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(100)]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [StringLength(100)]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(10)]
        [MaxLength(10)]
        [MinLength(6)]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password don't match.")]
        [Display(Name = "Confirm Password")]
        [StringLength(10)]
        [MaxLength(10)]
        [MinLength(6)]
        [PasswordPropertyText]
        public string ComparePassword { get; set; }

    }
}
