using System.Collections.Generic;

namespace DziennikUcznia.Models
{
    public class Teacher : ApplicationUser
    {
        public List<Class> ClassList { get; set; }
    }
}
