using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News.ViewModels
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "EmailRequired")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "PasswordRequired")]
        public string Password { get; set; }
    }
}
