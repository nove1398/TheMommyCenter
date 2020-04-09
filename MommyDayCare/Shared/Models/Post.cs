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

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedOn { get; set; }

        [Display(Name = "Type")]
        public PostType PostCategory { get; set; }

        [MaxLength(100, ErrorMessage = "100 characters max")]
        public string Title { get; set; }

        public string Body { get; set; }

        public string Attachment { get; set; }

        public enum PostType
        {
            Forum,
            Blog
        }
    }
}
