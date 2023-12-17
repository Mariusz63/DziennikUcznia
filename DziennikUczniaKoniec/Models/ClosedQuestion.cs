using System.Collections.Generic;

namespace DziennikUczniaKoniec.Models
{
    public class ClosedQuestion : AbstractQuestion
    {
        public virtual ICollection<ClosedQuestionOption> Options { get; set; }
    }
}