using System.Collections.Generic;

namespace DziennikUcznia.Models
{
    public class Parent 
    {
        public int ParentId { get; set; }
        // inne dane osobowe rodzica

        public virtual ICollection<Student> Children { get; set; }
    }
}