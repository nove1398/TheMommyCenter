using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.Models
{
    public class AppUserRole
    {
        [Key]
        public int AppUserRoleId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "At least 3 characters")]
        [MaxLength(200,ErrorMessage = "Max 200 Characters")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Max 500 characters")]
        public string Description { get; set; }
    }
}
