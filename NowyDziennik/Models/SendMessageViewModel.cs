using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NowyDziennik.Controllers
{
    public class SendMessageViewModel
    {
        [Required(ErrorMessage = "Content is required.")]
        [MaxLength(1000, ErrorMessage = "Content cannot exceed 1000 characters.")]
        public string Content { get; set; }

        public string ReceiverId { get; set; }
        public string ReceiverName { get; set; }
    }
}