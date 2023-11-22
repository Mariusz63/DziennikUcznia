namespace DziennikUcznia.Models
{
    public class TestAnswer
    {
        public int TestAnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        // inne informacje o odpowiedzi

        public virtual TestQuestion Question { get; set; }
    }
}