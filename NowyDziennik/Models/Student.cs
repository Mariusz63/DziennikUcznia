using System.ComponentModel.DataAnnotations;

namespace NowyDziennik.Models
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; } 
        public string ParentId {  get; set; }
    }
}