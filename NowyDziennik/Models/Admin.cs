using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NowyDziennik.Models
{
    public class Admin
    {
        [Key]
        public string AdminId {  get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}