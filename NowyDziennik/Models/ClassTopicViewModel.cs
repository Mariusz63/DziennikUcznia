using System.ComponentModel.DataAnnotations;
using System.Web;

namespace NowyDziennik.Models
{
    public class ClassTopicViewModel
    {
        public int ClassTopicViewModelId { get; set; }

        public string Topic { get; set; }

        public string Description { get; set; }

        public int ClassId { get; set; }

        public HttpPostedFileBase File { get; set; }
    }

}