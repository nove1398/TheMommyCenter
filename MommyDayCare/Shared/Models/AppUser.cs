using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.Models
{
    public class AppUser
    {

        [Key]
        public int AppUserId { get; set; }

        public Guid UserSlug { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegisteredOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? LastLogin { get; set; }

        [Display(Name = "First Name")]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MinLength(3, ErrorMessage = "Must be at least 3 characters")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Display Name")]
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

        [Display(Name = "Make Private")]
        public bool IsPrivate { get; set; }

        [Display(Name = "Avatar")]
        public string Avatar { get; set; }

        [MaxLength(500, ErrorMessage = "Maxmimum 500 characters")]
        public string Biography { get; set; }

        [Display(Name = "Sex")]
        public Gender Sex { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Activation Code")]
        public int? ActivationKey { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        [DisplayName("Group")]
        public int? AppUserGroupId { get; set; }
        public AppUserGroup AppUserGroup { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Message> MessageTo { get; set; }
        public virtual ICollection<Message> MessageFrom { get; set; }
        public virtual ICollection<UsersToRoles> UsersToRoles { get; set; }
        public virtual ICollection<AppUserFollowing> AppUserFollowers { get; set; }
        public virtual ICollection<AppUserFollowing> AppUserFollowees { get; set; }

        public enum Gender
        {
            Male,
            Female
        }
    }
}
