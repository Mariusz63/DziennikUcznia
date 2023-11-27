using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DziennikUczniaV3.Models
{
    public class Login
    {
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}