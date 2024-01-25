using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NowyDziennik.Models
{
    public class Test
    {
        [Key] 
        public int TestId { get; set; }
        public int SubjectId { get; set; }
        public string TeacherId { get; set; }//author
        public string TestName { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher {  get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
    }
}