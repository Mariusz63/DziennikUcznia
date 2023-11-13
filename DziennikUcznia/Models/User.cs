using System.ComponentModel.DataAnnotations;
using DziennikUcznia.Enum;

namespace DziennikUcznia.Models
{
    public class User
    {
        [Key]
        public int? Id{ get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string? Name{ get; set; }

        [Required]
        public string? LastName{ get; set; }

        [Required]
        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Role")]
        public Roles Roles { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
