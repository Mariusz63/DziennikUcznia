using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NowyDziennik.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MaxPoints { get; set; }

        public  int SubjectTopicId { get; set; }

        [ForeignKey("SubjectTopicId")]
        public virtual SubjectTopic SubjectTopic { get; set; }

        public  string TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual ApplicationUser Teacher { get; set; }

        // Relacja z pytaniami
        public ICollection<Question> Questions { get; set; }


        // public StudentGrade StudentGrade { get; set; }
    }
}