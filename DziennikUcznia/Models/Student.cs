namespace DziennikUcznia.Models
{
    public class Student : ApplicationUser
    {
        public int StudentId { get; set; }
        // inne dane osobowe ucznia

        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

    }
}
