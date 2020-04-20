using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.Models
{
    /*
     * A group of posts under the same theme
     */
    public class Collection
    {
        [Key]
        public int CollectionId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Max 20 characters")]
        public string Title { get; set; }

        
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
