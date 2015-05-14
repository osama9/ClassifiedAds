using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassifiedApp.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public virtual Country Country { get; set; }
    }
}