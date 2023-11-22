using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DziennikUcznia.Models
{
    public class Login:ApplicationUser
    {
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}