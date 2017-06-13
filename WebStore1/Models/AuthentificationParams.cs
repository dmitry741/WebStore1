using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebStore1.Models
{
    public class AuthentificationParams
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login is required")]
        [MinLength(1, ErrorMessage = "Login lenght has to be more than 1")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MinLength(3, ErrorMessage = "Login lenght has to be more than 3")]
        [DisplayName("Password")]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
    }
}