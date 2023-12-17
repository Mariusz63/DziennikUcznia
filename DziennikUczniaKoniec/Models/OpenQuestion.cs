using System.Collections.Generic;

namespace DziennikUczniaKoniec.Models
{
    public class OpenQuestion : AbstractQuestion
    {
        public int MaxPoints { get; set; }
        public int MaxAnswerLength { get; set; }

        public virtual ICollection<OpenQuestionAnswer> Answers { get; set; }
    }
}