using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikUcznia.Models
{
    public class Class : Student
    {
        [Key]
        public int? KlasaId { get; set; }

        [Required]
        public string Name { get; set; }

        //Wychowawca

        public List<Student> Students;
        public List<Subject> Subjects;

    }
}
