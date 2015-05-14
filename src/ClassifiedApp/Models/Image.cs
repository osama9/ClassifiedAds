using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassifiedApp.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        [MaxLength(450)]
        public string Identifier { get; set; }
    }
}