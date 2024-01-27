using System.ComponentModel.DataAnnotations;

namespace NowyDziennik.Models
{
    public class Admin
    {
        [Key]
        public string AdminId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}