using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.Models
{
    public class AppUserFollowing
    {

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        public int AppUserToFolloweeId { get; set; }
        public int AppUserFollowerId { get; set; }

        public AppUser AppUserFollower { get; set; }
        public AppUser AppUserFollowee { get; set; }
    }
}
