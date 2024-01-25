using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebGrease.Activities;

namespace NowyDziennik.Models
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateAdded { get; set; }
        public int FileTypeId { get; set; }

        [ForeignKey("FileTypeId")]
        public virtual FileType FileType { get; set; }

        public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }

    }
}