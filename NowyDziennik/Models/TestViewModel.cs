using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int GradeId { get; set; }
       // public string StudentId { get; set; }
        public float Score { get; set; }
        public int? TestId { get; set; }

        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }

        public ICollection<Question> Questions { get; set; }

        public List<ClassSelectionViewModel> ClassSelections { get; set; }

    }
}