using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikUczniaV3.Models
{
    public class Class 
    {
        [Key]
        public int? ClassId { get; set; }
        [Required]
        public string ClassName { get; set; }
        // inne informacje o klasie

        public virtual ICollection<Student> Students { get; set; }

        public virtual Teacher HomeroomTeacher { get; set; } //wychowawca

       // public virtual ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; } // Dodaj kolekcję nauczycieli, którzy przynależą do klasy
    }
}
