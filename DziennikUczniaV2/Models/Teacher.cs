using DziennikUczniaV2.Areas.Identity.Data;

namespace DziennikUcznia.Models
{
    public class Teacher : ApplicationUser
    {
        public List<Class> ClassList { get; set; }
    }
}
