using System.Collections.Generic;

namespace DziennikUczniaKoniec.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }

        // Navigation properties
        public virtual ICollection<ClassMembership> ClassMemberships { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        // ... other navigation properties
    }
}