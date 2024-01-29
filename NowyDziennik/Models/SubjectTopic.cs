using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NowyDziennik.Models
{
    public class SubjectTopic
    {
        [Key]
        public int SubjectTopicId { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public int TestId { get; set; }

        // Add a property to store the file content as byte array
        public byte[] FileContent { get; set; }

        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Grade> Grades { get; set; } // Oceny z przedmiotu
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<FileAttachment> FileAttachments { get; set; }
    }
}