using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikUcznia.Models
{
    public class TestQuestion
    {
        [Key]
        public int TestQuestionId { get; set; }
        public string QuestionText { get; set; }
        // inne informacje o pytaniu

        public virtual Test Test { get; set; }
        public virtual ICollection<TestAnswer> Answers { get; set; }
    }
}