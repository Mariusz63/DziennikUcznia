using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NowyDziennik.Models
{
    public class Conversation
    {
        [Key]
        public int ConversationId { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }

}