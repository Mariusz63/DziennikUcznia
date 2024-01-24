using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NowyDziennik.Models
{
    public class Parent
    {
        [Key] 
        public string ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    
    }
}