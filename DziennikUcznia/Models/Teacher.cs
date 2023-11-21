using System.Collections.Generic;

namespace DziennikUcznia.Models
{
    public class Teacher : ApplicationUser
    {
        public int TeacherId { get; set; }
        public List<Class> ClassList { get; set; }
        // czy wychowawca ? klasa
    }
}
