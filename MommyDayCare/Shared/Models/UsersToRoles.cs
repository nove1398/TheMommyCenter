using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.Models
{
    public class UsersToRoles
    {
        public int AppUserId { get; set; }
        public int AppUserRoleId { get; set; }

        public AppUser AppUser { get; set; }
        public AppUserRole AppUserRole { get; set; }
    }
}
