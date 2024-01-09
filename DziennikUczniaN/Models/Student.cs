using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace DziennikUczniaN.Models
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; }
        public string ParentId { get; set; }
        public int? ClassId { get; set; }

        [ForeignKey("StudentId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ParentId")]
        public virtual Parent Parent { get; set; }
        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }

        public virtual ICollection<TestAttempt> TestAttempts { get; set; }
        public virtual ICollection<StudentPrent> Prents { get; set; }

    }
}