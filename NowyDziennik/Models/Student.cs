using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NowyDziennik.Models
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; }
        public string ParentId { get; set; }
        public int ClassId { get; set; }

        [ForeignKey("StudentId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }

        [ForeignKey("ParentId")]
        public virtual Parent Parent { get; set; }

        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; } // Nowa linia
    }
}