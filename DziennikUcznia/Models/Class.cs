using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikUcznia.Models
{
    public class Class : Student
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<Student> Students;

    }
}
