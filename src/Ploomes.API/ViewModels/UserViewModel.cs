using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.API.ViewModels
{
    public class RegisterUserViewModel
    {

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(100, ErrorMessage = "{0} must be between {2} and {1} digits", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords must be identical.")]
        public string ConfirmPassword { get; set; }

    }
}
