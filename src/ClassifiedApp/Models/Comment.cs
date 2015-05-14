using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassifiedApp.Models
{
    public class Comment
    {
        public Comment()
        {
            this.CreatedAt = DateTime.Now;
        }
        public int CommentId { get; set; }
        public string Content { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ClassifiedAd ClassifiedAd{ get; set; }
        public DateTime CreatedAt { get; set; }
    }
}