using System.Collections.Generic;

namespace DziennikUczniaKoniec.Models
{
    public class OpenQuestion : Question
    {
        public int MaxPoints { get; set; }
        public int MaxAnswerLength { get; set; }

        public virtual ICollection<OpenTestAnswer> Answers { get; set; }
    }
}