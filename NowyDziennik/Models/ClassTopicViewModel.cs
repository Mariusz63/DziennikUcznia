﻿using System.Web;

namespace NowyDziennik.Models
{
    public class SubjectTopicViewModel
    {

        public string Topic { get; set; }

        public string Description { get; set; }

        public int SubjectId { get; set; }
        public int ClassId { get; set; }

        public HttpPostedFileBase File { get; set; }
    }

}