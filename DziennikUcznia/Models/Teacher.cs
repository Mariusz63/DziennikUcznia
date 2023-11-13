namespace DziennikUcznia.Models
{
    public class Teacher:User
    {
        public List<Class> ClassList { get; set; }
    }
}
