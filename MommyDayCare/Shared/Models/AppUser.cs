using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.Models
{
    public class AppUser
    {

        [Key]
        public int AppUserId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegisteredOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedOn { get; set; }

        [Display(Name = "First Name")]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Too long of a name")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Salt { get; set; }

        [Display(Name = "Login Attempts")]
        public int LoginAttemps { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public string Avatar { get; set; }

        [MaxLength(500, ErrorMessage = "Too long, try cutting back just a tad")]
        public string Bio { get; set; }

        public Gender Sex { get; set; }

        public string Country { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        public virtual ICollection<AppUserRole> UserRoles { get; set; }

        public enum Gender
        {
            Male,
            Female
        }
    }
}
