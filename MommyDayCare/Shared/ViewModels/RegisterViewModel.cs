using MommyDayCare.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        public string Username { get; set; }

        public string Country { get; set; }

        public DateTime Birthday { get; set; }

        public AppUser.Gender Sex { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
