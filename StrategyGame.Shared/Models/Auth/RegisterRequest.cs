using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace StrategyGame.Shared.Models.Auth
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string NickName { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "A jelszónak legalább 6 karakterből kell állnia.")]
        //At least one Uppercase one Lowercase and a special character
        [RegularExpression(@"^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{6,}$", ErrorMessage = "A jelszónak tartalmaznia kell legalább egy nagybetűt és egy speciális karaktert.")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
