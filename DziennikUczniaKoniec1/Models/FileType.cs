﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikUczniaKoniec.Models
{
    public class FileType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}