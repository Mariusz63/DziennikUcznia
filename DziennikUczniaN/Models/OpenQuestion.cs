using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikUczniaN.Models
{
    public class OpenQuestion : AbstractQuestion
    {
        public int MaxPoints { get; set; }
        public int MaxAnswerLength { get; set; }

        public virtual ICollection<OpenTestAnswer> Answers { get; set; }
    }
}