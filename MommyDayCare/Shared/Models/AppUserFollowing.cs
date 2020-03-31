using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.Models
{
    public class AppUserFollowing
    {
        [Key]
        public int AppUserFollowingId { get; set; }

        public int AppUserFollowerId { get; set; }
        public int AppUserFolloweeId { get; set; }

        public AppUser AppUserFollower { get; set; }
        public AppUser AppUserFollowee { get; set; }
    }
}
