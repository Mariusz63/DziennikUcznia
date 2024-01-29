using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NowyDziennik.Models
{
    public class SubjectViewModel
    {
        [Required]
        public string SubjectName { get; set; }

        [Required]
        public string SubjectDescription { get; set; }

        public int ClassId { get; set; }
    }
}