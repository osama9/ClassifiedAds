using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassifiedApp.Models
{
    public class Category
    {
        public Category()
        {
            this.IsActive = true;
        }
        public int CategoryId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<ClassifiedAd> ClassifiedAds { get; set; }
    }
}