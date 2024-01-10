using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DziennikUczniaKoniec.Models
{
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }
        public string AuthorId { get; set; }
        [Display(Name = "Creation time")]
        public DateTime CreationTime { get; set; }
        public string Content { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Administrator Author { get; set; }
    }
}