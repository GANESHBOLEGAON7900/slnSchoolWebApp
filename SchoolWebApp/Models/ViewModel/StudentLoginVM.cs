using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SchoolWebApp.Models.ViewModel
{
    public class StudentLoginVM
    {
        public StudentLoginVM()
        {
        }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100)]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(10)]
        [MaxLength(10)]
        [MinLength(6, ErrorMessage = "Minimum password length is 6 characters.")]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
