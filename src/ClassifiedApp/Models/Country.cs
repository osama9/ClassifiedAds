using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassifiedApp.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}