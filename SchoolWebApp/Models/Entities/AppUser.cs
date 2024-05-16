using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace SchoolWebApp.Models.Entities
{

    public class AppUser:IdentityUser
    {
        public int Id { get; set; }

        [StringLength(50)]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [StringLength(10)]
        [MaxLength(10)]
        [MinLength(6)]
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
