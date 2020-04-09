using System;
using System.Collections.Generic;
using System.Text;

namespace MommyDayCare.Shared.Models
{
    public class PostTag
    {
        public int PostIt { get; set; }
        public int TagId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
