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

        public int ClassTopicId { get; set; }

        [ForeignKey("ClassTopicId")]
        public virtual ClassTopic ClassTopic { get; set; }
    }
}