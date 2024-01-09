using System.Collections.Generic;

namespace DziennikUczniaN.Models
{
    public class ClosedQuestion : AbstractQuestion
    {
        public virtual ICollection<ClosedQuestionOption> Options { get; set; }
    }
}