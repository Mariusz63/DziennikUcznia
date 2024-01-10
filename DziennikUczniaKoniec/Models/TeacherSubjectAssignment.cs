namespace DziennikUczniaKoniec.Models
{
    public class TeacherSubjectAssignment
    {
        public int TeacherSubjectAssignmentId { get; set; }

        // Foreign keys
        public string TeacherId { get; set; }
        public int SubjectId { get; set; }

        // Navigation properties
        public virtual Teacher Teacher { get; set; }
        public virtual Subject Subject { get; set; }
    }
}