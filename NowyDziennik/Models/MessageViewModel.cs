using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NowyDziennik.Models
{
    public class MessageViewModel
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public string SenderId { get; set; }

        public string RecipientId { get; set; }

        public int FileTypeId { get; set; }
    }

}