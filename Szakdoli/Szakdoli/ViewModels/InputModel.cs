using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Szakdoli.Models
{
    
    public class InputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail cím")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Jelszó")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Jelszó megerősítése")]
        [Compare("Password", ErrorMessage = "A jelszónak és a jelszó megerősítésnek egyezni kell.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Telephely")]
        public string Raktar { get; set; }
        [Display(Name = "Teljes név")]
        public string TeljesNev { get; set; }
        [Display(Name = "Beosztás")]
        public string Role { get; set; }
    }
}
