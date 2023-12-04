using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikUcznia.Models
{
    public class Class 
    {
        [Key]
        public int? ClassId { get; set; }

        [Required]
        public string ClassName { get; set; }

        // inne informacje o klasie
        [Required]
        public string Code { get; set; }

        public int? Credits { get; set; }

        public virtual ICollection<Subject> Subject { get; } = new List<Subject>();

        public virtual Teacher Lecturer { get; set; }
    }
}
