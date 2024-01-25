using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NowyDziennik.Models
{
    public class StudentGrade
    {
        [Key]
        public int StudentGradeId { get; set; }

        public string StudentId { get; set; }
        public int GradeId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("GradeId")]
        public virtual Grade Grade { get; set; }


    }
}