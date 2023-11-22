using System.Collections.Generic;

namespace DziennikUcznia.Models
{
    public class Teacher : ApplicationUser
    {
        public int TeacherId { get; set; }
        // inne dane osobowe nauczyciela

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
