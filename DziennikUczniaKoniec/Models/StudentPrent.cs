namespace DziennikUczniaKoniec.Models
{
    public class StudentPrent
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public int ParentID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Parent Parent { get; set; }
    }
}