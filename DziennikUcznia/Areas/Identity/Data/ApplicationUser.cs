using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DziennikUcznia.Enum;
using Microsoft.AspNetCore.Identity;

namespace DziennikUcznia.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [Key, Column(Order = 1)]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Data urodzenia")]
    [DataType(DataType.Date)]
    public DateTime? BirthDate { get; set; }

    [EmailAddress]
    [Display(Name = "Email")]
    [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
    public string? Email { get; set; }

    [Required]
    [Display(Name = "Role")]
    public Roles Roles { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string? Password { get; set; }

    [NotMapped]
    [Required]
    [System.ComponentModel.DataAnnotations.Compare("Password")]
    public string ConfirmPassword { get; set; }

    public string FullName()
    {
        return this.FirstName + " " + this.LastName;
    }
}

