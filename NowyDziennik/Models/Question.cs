using System.Collections.Generic;

namespace NowyDziennik.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }

        // Relacja z testem
        public int TestId { get; set; }
        public Test Test { get; set; }

        // Relacja z odpowiedziami
        public ICollection<Answer> Answers { get; set; }
    }
}