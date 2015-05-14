using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ClassifiedApp.Models;
using ClassifiedApp.Models.Initializers;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ClassifiedApp.DAL
{
    public class ClassifiedContext : ApplicationDbContext
    {
        //public ClassifiedContext()
        //    : base("DefaultConnection")
        //{

        //    //Database.SetInitializer<ClassifiedContext>(new ClassifiedDbInitializer<ClassifiedContext>());
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ClassifiedAd> ClassifiedAds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<Image>().Property(i=>i.Identifier)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, 
                new IndexAnnotation(new IndexAttribute("Identity"){IsUnique = true}));
            base.OnModelCreating(modelBuilder);
        }
    }
}