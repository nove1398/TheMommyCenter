using MommyDayCare.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.ViewModels
{
    public class RegisterRequest
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Username { get; set; }

        public string Country { get; set; }

        
        public DateTime Birthday { get; set; }

        public AppUser.Gender Sex { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Username} {Country} {Birthday.ToString("dd-MMM-yyyy")} {Sex} {Password}";
        }
    }
}
