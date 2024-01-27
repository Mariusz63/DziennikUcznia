﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NowyDziennik.Models
{
    public class StudentSubject
    {
        [Key]
        public int StudentSubjectId { get; set; }

        public string StudentId { get; set; }
        public int SubjectId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
    }
}