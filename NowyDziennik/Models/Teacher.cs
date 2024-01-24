using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NowyDziennik.Models
{
    public class Teacher
    {
        [Key]
        public string TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}