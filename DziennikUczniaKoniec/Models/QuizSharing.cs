﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DziennikUczniaKoniec.Models
{
    public class QuizSharing
    {
        [Key, Column(Order = 0)]
        public int ClassId { get; set; }
        [Key, Column(Order = 1)]
        public int QuizId { get; set; }
        /*public DateTime OpenFrom { get; set; }
        public DateTime OpenTo { get; set; }*/
        [Range(0, 1)]
        public float GradeWeight { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }
        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }
    }
}