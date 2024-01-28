using System;
using System.Collections.Generic;

namespace NowyDziennik.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MaxPoints { get; set; }

        // Relacja z przedmiotem
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        // Relacja z nauczycielem
        public string TeacherId { get; set; }
        public ApplicationUser Teacher { get; set; }

        // Relacja z pytaniami
        public ICollection<Question> Questions { get; set; }

        // public StudentGrade StudentGrade { get; set; }
    }
}