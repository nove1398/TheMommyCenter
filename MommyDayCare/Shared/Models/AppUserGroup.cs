using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.Models
{
    public class AppUserGroup
    {
        [Key]
        public int AppUserGroupId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "At least 3 characters")]
        public string Name { get; set; }

        [MinLength(5, ErrorMessage = "At least 5 characters")]
        [MaxLength(500, ErrorMessage = "Maxmimum 500 characters")]
        public string Description { get; set; }
    }
}
