using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MommyDayCare.Shared.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public int SenderId { get; set; }
        public AppUser Sender { get; set; }
        
        public int ReceiverId { get; set; }
        public AppUser Receiver { get; set; }

        public string Attachment { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public string Body { get; set; }
    }
}
