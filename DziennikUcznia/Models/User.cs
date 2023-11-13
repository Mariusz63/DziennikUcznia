using DziennikUcznia.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DziennikUcznia.Models
{
    public class User
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Login { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Name { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string? Email { get; set; }

        private bool _isEmailConfirmed { get; set; } = false;

        [Required]
        [Display(Name = "Role")]
        public Roles Roles { get; set; }

        [Required]
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
            return this.Name + " " + this.LastName;
        }

    }
}
