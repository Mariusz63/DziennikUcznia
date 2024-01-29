using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NowyDziennik.Models
{
    public class StudentClass
    {
        [Key]
        public int StudentClassId { get; set; }

        public string StudentId { get; set; }
        public int ClassId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }
    }
}