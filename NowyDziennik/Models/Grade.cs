using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NowyDziennik.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public int TestId { get; set; }
        public DateTime GradeDate { get; set; }

      //  public int SubjectId { get; set; }
        public string TeacherId { get; set; }
      //  public string StudentId { get; set; }

       // [ForeignKey("StudentId")]
       // public virtual Student Student { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }

       // [ForeignKey("SubjectId")]
       // public virtual Subject Subject { get; set; }

        public virtual ICollection<StudentGrade> StudentGrades { get; set; }

        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
    }
}