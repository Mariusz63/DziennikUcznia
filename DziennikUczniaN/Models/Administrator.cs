using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DziennikUczniaN.Models
{
    public class Administrator
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<GlobalAnnouncement> Announcements { get; set; }
    }
}