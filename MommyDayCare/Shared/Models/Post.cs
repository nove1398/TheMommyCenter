using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
    }
}
