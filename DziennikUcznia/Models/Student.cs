using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Antlr.Runtime;

namespace DziennikUcznia.Models
{
    public class Student 
    {
        [Key, ForeignKey("ApplicationUser")]
        public int StudentId { get; set; }

        public virtual Class Class { get; set; }

        // Relacja jeden do jeden z modelem ApplicationUser
        public virtual ApplicationUser ApplicationUserId { get; set; }

        public virtual Parent ParentId { get; set; }

    }
}
