using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DziennikUczniaN.Models
{
    public class AbstractQuestion
    {
        [Key]
        public int Id { get; set; }
        public int? TestId { get; set; }
        public string Content { get; set; }

        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
    }
}