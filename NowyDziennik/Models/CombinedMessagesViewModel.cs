using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NowyDziennik.Models
{
    public class CombinedMessagesViewModel
    {
        public IEnumerable<Message> SentMessages { get; set; }
        public IEnumerable<Message> ReceivedMessages { get; set; }
    }

}