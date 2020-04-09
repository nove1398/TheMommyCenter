using System;
using System.Collections.Generic;
using System.Text;

namespace MommyDayCare.Shared.Models
{
    public class PostCollection
    {
        public int PostId { get; set; }
        public int CollectionId { get; set; }

        public Post Post { get; set; }
        public Collection Collection { get; set; }

    }
}
