using System.ComponentModel.DataAnnotations;

namespace NowyDziennik.Models
{
    public class ClassSubject
    {
        [Key]
        public int ClassSubjectId { get; set; }

        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }

}