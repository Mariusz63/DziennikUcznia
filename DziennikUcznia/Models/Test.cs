using System;
using System.Collections.Generic;

namespace DziennikUcznia.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        // inne informacje o teście

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<TestQuestion> Questions { get; set; }
    }
}