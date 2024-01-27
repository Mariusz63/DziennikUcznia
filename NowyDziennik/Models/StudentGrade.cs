using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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