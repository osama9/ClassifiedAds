using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassifiedApp.Models
{
    public class ClassifiedAd
    {
        public ClassifiedAd()
        {
            this.CreatedAt = DateTime.Now; //Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        public int ClassifiedAdId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public bool IsPublished { get; set; }
        public bool IsExpired { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual City City { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}