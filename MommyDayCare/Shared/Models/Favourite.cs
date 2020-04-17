using System.ComponentModel.DataAnnotations;
using static MommyDayCare.Shared.Models.Post;

namespace MommyDayCare.Shared.Models
{
    public class Favourite
    {
        [Key]
        public int FavouriteId { get; set; }

        public PostType ItemType { get; set; }

        public int ItemId { get; set; }
    }
}
