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
        [MinLength(3, ErrorMessage = "Too short")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
