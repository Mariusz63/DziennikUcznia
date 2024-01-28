using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace NowyDziennik.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime DateTime { get; set; }= DateTime.Now;
        public int FileTypeId { get; set; }

        public string SenderId { get; set; }
        // public int ConversationId { get; set; }

        //[ForeignKey("ConversationId")]
        //public virtual Conversation Conversation { get; set; }
        public string RecipientId { get; set; }

        [ForeignKey("RecipientId")]
        public ApplicationUser Recipient { get; set; }

        [ForeignKey("SenderId")]
        public ApplicationUser Sender { get; set; }
        public virtual ICollection<Announcement> Announcement { get; set; }

    }
}