using System.Collections.Generic;

namespace NowyDziennik.Models
{
    public class ClassSelectionViewModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public List<StudentSelectionViewModel> Students { get; set; }
    }
}