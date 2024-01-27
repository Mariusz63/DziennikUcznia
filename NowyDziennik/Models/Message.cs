using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NowyDziennik.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        public string Content { get; set; }
        public string SenderId { get; set; }
        public DateTime DateTime { get; set; } //send time

        [ForeignKey("SenderId")]
        public virtual ApplicationUser Sender { get; set; }


    }
}