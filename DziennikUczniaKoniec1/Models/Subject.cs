﻿using System.Collections.Generic;

namespace DziennikUczniaKoniec.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }

        public virtual ICollection<TeacherClassSubject> TeacherClassSubjects { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Test> Test { get; set; }
        public virtual ICollection<TeacherSubjectAssignment> TeacherAssignments { get; set; }

    }
}