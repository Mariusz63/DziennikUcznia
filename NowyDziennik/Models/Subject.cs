﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NowyDziennik.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; } = string.Empty;
        [Required]
        public string SubjectDescription { get; set; }

        public virtual ICollection<TeacherClassSubject> TeacherClassSubjects { get; set; }

    }
}