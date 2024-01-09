using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace DziennikUczniaN.Models
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