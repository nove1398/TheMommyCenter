using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MommyDayCare.Shared.Models.Post;

namespace MommyDayCare.Shared.Models
{
    public class Favourite
    {
        [Key]
        public int FavouriteId { get; set; }

        [Required]
        public PostType ItemType { get; set; }

        [Required]
        public int ItemId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
    }
}
