using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NowyDziennik.Models
{
    public class FileType
    {
        [Key]
        public int FileTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}