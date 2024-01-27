using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NowyDziennik.Models
{
    public class ClassTopic
    {
        [Key]
        public int ClassTopicId { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }

        // Add a property to store the file content as byte array
        public byte[] FileContent { get; set; }

        public int ClassId { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }

        public virtual ICollection<FileAttachment> FileAttachments { get; set; }
    }
}