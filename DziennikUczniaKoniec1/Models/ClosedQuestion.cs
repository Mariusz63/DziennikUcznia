using System.Collections.Generic;

namespace DziennikUczniaKoniec.Models
{
    public class ClosedQuestion : Question
    {
        public virtual ICollection<ClosedQuestionOption> Options { get; set; }
    }
}