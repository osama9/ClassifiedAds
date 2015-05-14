using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassifiedApp.Models;
using System.IO;

namespace ClassifiedApp.ViewModels
{
    public class ClassifiedAdViewModel
    {
        public int ClassifiedAdId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}