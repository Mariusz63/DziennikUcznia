using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikUczniaV3.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        // inne informacje o przedmiocie

        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
