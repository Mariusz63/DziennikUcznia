﻿namespace NowyDziennik.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }

        // Relacja z pytaniem
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}