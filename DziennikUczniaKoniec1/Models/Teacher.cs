using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DziennikUczniaKoniec.Models
{
    public class Teacher
    {
        [Key]
        public string TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<TeacherClassSubject> TeacherClassSubjects { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}