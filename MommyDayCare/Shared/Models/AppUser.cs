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

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
