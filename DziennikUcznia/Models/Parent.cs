using System.Collections.Generic;

namespace DziennikUcznia.Models
{
    public class Parent : ApplicationUser
    {
        public int ParentId { get; set; }
        // inne dane osobowe rodzica

        public virtual ICollection<Student> Children { get; set; }
    }
}