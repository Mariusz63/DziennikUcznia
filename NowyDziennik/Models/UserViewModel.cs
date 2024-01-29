using System.ComponentModel.DataAnnotations;

namespace NowyDziennik.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Display(Name = "FirstName", ResourceType = typeof(Resource))]
        public string FirstName { get; set; }
        [Display(Name = "LastName", ResourceType = typeof(Resource))]
        public string LastName { get; set; }
        public string Role { get; set; }
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }
    }

}