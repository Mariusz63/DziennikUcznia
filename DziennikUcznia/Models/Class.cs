using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikUcznia.Models
{
    public class Class : Student
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        public string ClassName { get; set; }
        // inne informacje o klasie

        public virtual ICollection<Student> Students { get; set; }

        public virtual Teacher HomeroomTeacher { get; set; } //wychowawca

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
