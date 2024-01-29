using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NowyDziennik.Models
{
    public class FileAttachment
    {
        [Key]
        public int FileAttachmentId { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }

        public int SubjectTopicId { get; set; }

        [ForeignKey("SubjectTopicId")]
        public virtual SubjectTopic SubjectTopics { get; set; }
    }
}