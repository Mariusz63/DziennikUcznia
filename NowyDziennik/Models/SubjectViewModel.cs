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
        [Display(Name = "Subject Name", ResourceType = typeof(Resource))]
        public string SubjectName { get; set; }

        [Required]
        [Display(Name = "Subject Description", ResourceType = typeof(Resource))]
        public string SubjectDescription { get; set; }

        public int ClassId { get; set; }
    }
}