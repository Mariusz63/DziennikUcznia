using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DziennikUczniaV3.Models
{
    public class Student 
    {
        [Key, ForeignKey("ApplicationUser")]
        public int StudentId { get; set; }

        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

        // Relacja jeden do jeden z modelem ApplicationUser
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
