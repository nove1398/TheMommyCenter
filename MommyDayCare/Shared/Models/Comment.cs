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

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        public CommentStatus Status { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "At least 5 characters")]
        public string Body { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        public int PostId { get; set; }
        public Post Post { get; set; }

        public enum CommentStatus
        {
            Reviewing,
            Published,
            Deleted
        }
    }
}
