using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DziennikUczniaKoniec.Models
{
    public class Attachment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? MessageId { get; set; }
        public int? FileTypeId { get; set; }
        public string Data { get; set; }

        [ForeignKey("MessageId")]
        public virtual Message Message { get; set; }
        [ForeignKey("FileTypeId")]
        public virtual FileType FileType { get; set; }
    }
}