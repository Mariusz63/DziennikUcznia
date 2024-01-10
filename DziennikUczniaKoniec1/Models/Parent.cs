using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DziennikUczniaKoniec.Models
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