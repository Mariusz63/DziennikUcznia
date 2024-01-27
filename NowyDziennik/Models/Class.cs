using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NowyDziennik.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string SupervisorId { get; set; }
        public string Description { get; set; }

        [ForeignKey("SupervisorId")]
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<TeacherClassSubject> TeacherClassSubjects { get; set; }

        public virtual ICollection<ClassTopic> ClassTopics { get; set; }

    }
}