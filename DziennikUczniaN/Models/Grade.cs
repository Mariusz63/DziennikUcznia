﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DziennikUczniaN.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        [Range(1, 6)]
        public float Value { get; set; }
        [Range(0, 1)]
        public float Weight { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public string StudentId { get; set; }
        public string TeacherId { get; set; }
        public int SubjectId { get; set; } // not null

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
    }
}