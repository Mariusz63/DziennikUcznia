﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikUczniaKoniec.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Syllabus { get; set; } // łańcuch bajtów pliku pdf z syllabusem

        public virtual ICollection<TeacherClassSubject> TeacherClassSubjects { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        // public virtual ICollection<SecondForeignLanguageGroup> SecondForeignLanguageGroups { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}