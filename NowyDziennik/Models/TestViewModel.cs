using System;
using System.Collections.Generic;

namespace NowyDziennik.Models
{
    public class TestViewModel
    {
        public int TestViewModelId { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MaxPoints { get; set; }
        public int SubjectId { get; set; }
        public string TeacherId { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}