using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DziennikUcznia.Models
{
    public class Teacher
    {
        [Key, ForeignKey("ApplicationUser")]
        public int TeacherId { get; set; }
        // inne dane osobowe nauczyciela

        public virtual ICollection<Subject> Subjects { get; set; }

        public virtual ICollection<Class> Classes { get; set; } // Dodaj kolekcję klas, do których należy nauczyciel
      
        // Relacja jeden do jeden z modelem ApplicationUser
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
