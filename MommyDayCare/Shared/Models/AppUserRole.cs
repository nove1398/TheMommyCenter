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

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
