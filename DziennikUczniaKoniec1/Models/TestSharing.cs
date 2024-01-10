using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DziennikUczniaKoniec.Models
{
    public class TestSharing
    {
        [Key, Column(Order = 0)]
        public int ClassId { get; set; }
        [Key, Column(Order = 1)]
        public int TestId { get; set; }
        [Range(0, 1)]
        public float GradeWeight { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }
        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
    }
}