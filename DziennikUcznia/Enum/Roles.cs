using System.ComponentModel.DataAnnotations;

namespace DziennikUcznia.Enum
{
    public enum Roles
    {
        [Display(Name = "Student")]
        Student,

        [Display(Name = "Teacher")]
        Teacher,

        [Display(Name = "Parent")]
        Parent,

        [Display(Name = "Administrator")]
        Admin

    }
}
