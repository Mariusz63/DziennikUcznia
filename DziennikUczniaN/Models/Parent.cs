using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DziennikUczniaN.Models
{
    public class Parent
    {
        [Key]
        public string ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<StudentPrent> Childrens { get; set; }
    }
}