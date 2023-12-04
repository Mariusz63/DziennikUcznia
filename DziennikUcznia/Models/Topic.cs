using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace DziennikUcznia.Models
{
    public class Topic
    {
        [Key]
        public int TopicId {  get; set; }
        [Required]
        public string TopicName { get; set; } // tytul i nazwa

        public string TopicDescription { get; set; } = string.Empty; // opis

        public IFormFile Plik { get; set; }

    }
}