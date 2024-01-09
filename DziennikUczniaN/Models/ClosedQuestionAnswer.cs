using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DziennikUczniaN.Models
{
    public class ClosedQuestionAnswer
    {
        [Key, Column(Order = 0)]
        public int TestAttemptId { get; set; }
        [Key, Column(Order = 1)]
        public int SelectedOptionId { get; set; }

        [ForeignKey("TestAttemptId")]
        public virtual TestAttempt TestAttempt { get; set; }
        [ForeignKey("SelectedOptionId")]
        public virtual ClosedQuestionOption SelectedOption { get; set; }
    }
}