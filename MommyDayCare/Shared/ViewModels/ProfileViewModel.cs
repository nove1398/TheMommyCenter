using MommyDayCare.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.ViewModels
{
    class ProfileViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Sex")]
        public AppUser.Gender Sex { get; set; }


        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
