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

        [Display(Name = "Owner")]
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedOn { get; set; }

        [Required]
        [Display(Name = "Post Type")]
        public PostType PostCategory { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "100 characters max")]
        [MinLength(5, ErrorMessage = "At least 5 characters")]
        public string Title { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "At least 5 characters")]
        public string Body { get; set; }

        public string Attachment { get; set; }

        public Guid Slug { get; set; }

        [Required]
        [Display(Name = "Post Status")]
        public PostStatus Status { get; set; }

        public int CommentCount { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }

        public enum PostStatus
        {
            Active,
            Pending,
            Disabled
        }

        public enum PostType
        {
            Forum,
            Journal
        }
    }
}
