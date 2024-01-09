using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DziennikUczniaN.Models
{
    public class GlobalAnnouncement
    {
        [Key]
        public int Id { get; set; }
        public string AuthorId { get; set; }
        [Display(Name = "Creation time")]
        public DateTime ModificationTime { get; set; }
        public string Content { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Administrator Author { get; set; }
    }
}