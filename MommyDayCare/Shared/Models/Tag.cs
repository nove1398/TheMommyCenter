using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "15 characters max")]
        [MinLength(3, ErrorMessage = "At least 3 characters")]
        public string Name { get; set; }
    }
}
