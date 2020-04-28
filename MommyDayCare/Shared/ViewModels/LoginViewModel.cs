using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password too short")]
        public string Password { get; set; }

        public string ResponseMessage { get; set; }

        public string Token { get; set; }

        public DateTime TokenExpiry { get; set; }

        public string[] Errors { get; set; }
    }
}
