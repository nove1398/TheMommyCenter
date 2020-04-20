using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Deleted { get; set; }

        [Required]
        public string Text { get; set; }

        public int AppUserId { get; set; }

        public AppUser AppUser { get; set; }


        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
