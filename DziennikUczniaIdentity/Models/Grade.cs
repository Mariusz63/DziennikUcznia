using System;
using System.ComponentModel.DataAnnotations;

namespace DziennikUczniaV3.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        [Range(1, 6, ErrorMessage = "Wybierz ocene w przedziale od 1 do 6.")]
        public int Value { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        // przedmiot

    }
}
