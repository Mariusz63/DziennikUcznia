using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NowyDziennik.Models
{
    public class AnnouncementUser
    {
        [Key]
        public int AnnouncementUserId { get; set; }
        public int AnnouncementId { get; set; }
        public string UserId { get; set; }

        [ForeignKey("AnnouncementId")]
        public virtual Announcement Announcement { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}