using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DziennikUczniaN.Models
{
    public class TestAttempt
    {
        [Key]
        public int Id { get; set; }
        public int? TestId { get; set; }
        public string StudentId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }

        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        public virtual ICollection<OpenTestAnswer> OpenQuestionAnswers { get; set; }
        public virtual ICollection<ClosedQuestionAnswer> ClosedQuestionAnswers { get; set; }
    }
}