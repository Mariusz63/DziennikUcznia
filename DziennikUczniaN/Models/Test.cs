using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DziennikUczniaN.Models
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }
        public int? SubjectId { get; set; }
        public string AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, int.MaxValue)]
        public int Duration { get; set; }
        public DateTime ModificationTime { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Teacher Author { get; set; }
        public virtual ICollection<TestAttempt> TestAttempts { get; set; }
        public virtual ICollection<OpenQuestion> OpenQuestions { get; set; }
        public virtual ICollection<ClosedQuestion> ClosedQuestions { get; set; }
        public virtual ICollection<TestSharing> TestSharings { get; set; }
    }
}