using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ClassifiedApp.DAL;
using ClassifiedApp.Models;
using System.Web.Mvc;
using System.Web;

namespace ClassifiedApp.Controllers.APIs
{
    public class ClassifiedAdsAPIController : ApiController
    {
        private ClassifiedContext db = new ClassifiedContext();

        // GET: api/ClassifiedAdsAPI
        public IHttpActionResult GetClassifiedAds(int Id = 0)
        {
            IQueryable classifiedAds = null;
            if (Id > 0)
            {
                classifiedAds = db.ClassifiedAds.Where(c => c.Category.CategoryId == Id).Select(ads => new
                {
                    ads.Title,
                    ads.Description,
                    ads.ClassifiedAdId,
                    ads.CreatedAt,
                    imageUrl = ads.Images.FirstOrDefault().Path,
                    User = new {
                        ads.User.UserName
                    },
                    City = new
                    {
                        ads.City.EnglishName,
                        ads.City.ArabicName
                    }
                }).OrderByDescending(c => c.CreatedAt);
            }
            else 
            { 
                classifiedAds= db.ClassifiedAds.Select(ads => new
                {
                    ads.Title,
                    ads.Description,
                    ads.ClassifiedAdId,
                    ads.CreatedAt,
                    imageUrl = ads.Images.FirstOrDefault().Path,
                    User = new
                    {
                        ads.User.UserName
                    },
                    City = new
                    {
                        ads.City.EnglishName,
                        ads.City.ArabicName
                    }
                }).OrderByDescending(c => c.CreatedAt);
            }
            //var ads = new {ads =  db.ClassifiedAds.ToList()};
            return Ok(classifiedAds);
        }

        public IHttpActionResult GetCities()
        {
            var cities = db.Cities.Select(c => new
            {
                c.ArabicName,
                c.CityId,
                c.EnglishName
            });
            return Ok(cities);
        }

        public IHttpActionResult GetCategories()
        {
            var categories = db.Categories.Where(c =>c.IsActive == true).Select(c => new
            {
                c.CategoryId,
                c.EnglishName,
                c.ArabicName
            });
            return Ok(categories);
        }

        // GET: api/ClassifiedAdsAPI/5
        [ResponseType(typeof(ClassifiedAd))]
        public IHttpActionResult GetClassifiedAd(int id)
        {
            ClassifiedAd classifiedAd = db.ClassifiedAds.Find(id);
            if (classifiedAd == null)
            {
                return NotFound();
            }

            return Ok(classifiedAd);
        }

        // PUT: api/ClassifiedAdsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClassifiedAd(int id, ClassifiedAd classifiedAd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classifiedAd.ClassifiedAdId)
            {
                return BadRequest();
            }

            db.Entry(classifiedAd).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassifiedAdExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ClassifiedAdsAPI
        [ResponseType(typeof(ClassifiedAd))]
        public IHttpActionResult PostClassifiedAd(ClassifiedAd classifiedAd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClassifiedAds.Add(classifiedAd);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = classifiedAd.ClassifiedAdId }, classifiedAd);
        }

        // DELETE: api/ClassifiedAdsAPI/5
        [ResponseType(typeof(ClassifiedAd))]
        public IHttpActionResult DeleteClassifiedAd(int id)
        {
            ClassifiedAd classifiedAd = db.ClassifiedAds.Find(id);
            if (classifiedAd == null)
            {
                return NotFound();
            }

            db.ClassifiedAds.Remove(classifiedAd);
            db.SaveChanges();

            return Ok(classifiedAd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassifiedAdExists(int id)
        {
            return db.ClassifiedAds.Count(e => e.ClassifiedAdId == id) > 0;
        }
    }
}