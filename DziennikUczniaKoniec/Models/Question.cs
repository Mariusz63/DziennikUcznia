using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DziennikUczniaKoniec.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public int? TestId { get; set; }
        public string Content { get; set; }

        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
    }
}