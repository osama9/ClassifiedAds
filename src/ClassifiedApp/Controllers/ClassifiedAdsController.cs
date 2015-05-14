using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassifiedApp.DAL;
using ClassifiedApp.Models;
using Microsoft.AspNet.Identity;
using ClassifiedApp.ViewModels;

namespace ClassifiedApp.Controllers
{
    public class ClassifiedAdsController : Controller
    {
        private ClassifiedContext db = new ClassifiedContext();

        // GET: ClassifiedAds
        public ActionResult Index()
        {
            return View(db.ClassifiedAds.ToList());
        }

        // GET: ClassifiedAds/Details/5
        [Route("ClassifiedAd/{id}", Name="Detail")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassifiedAd classifiedAd = db.ClassifiedAds.Find(id);
            if (classifiedAd == null)
            {
                return HttpNotFound();
            }
            ClassifiedAdViewModel classifiedAdVM = new ClassifiedAdViewModel();
            classifiedAdVM.ClassifiedAdId = classifiedAd.ClassifiedAdId;
            classifiedAdVM.Title = classifiedAd.Title;
            classifiedAdVM.Description = classifiedAd.Description;
            return View(classifiedAdVM);
        }

        // GET: ClassifiedAds/Create
        [Authorize]
        public ActionResult Create()
        {
            var cities = db.Cities.ToList();
            //ViewBag.Cities = 
            return View();
        }

        // POST: ClassifiedAds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassifiedAdViewModel classifiedAdVM)
        {
            ClassifiedAd classifiedAd = new ClassifiedAd();
            if (ModelState.IsValid)
            {
                string[] images = null;
                if(classifiedAdVM.Image != null)
                   images = classifiedAdVM.Image.Split(';');

                classifiedAd.Title = classifiedAdVM.Title;
                classifiedAd.Description = classifiedAdVM.Description;
                classifiedAd.City = db.Cities.Find(Convert.ToInt32(Request.Form["City"]));
                classifiedAd.Category = db.Categories.Find(Convert.ToInt32(Request.Form["Category"]));
                classifiedAd.User = db.Users.Find(User.Identity.GetUserId());
                classifiedAd.Images = new List<Image>();
                if (images != null)
                {
                    foreach (string image in images)
                    {
                        var img = db.Images.Where(i => i.Identifier == image).FirstOrDefault();
                        if (img != null)
                            classifiedAd.Images.Add(img);
                    }
                }
                
                db.ClassifiedAds.Add(classifiedAd);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(classifiedAdVM);
        }

        // GET: ClassifiedAds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassifiedAd classifiedAd = db.ClassifiedAds.Find(id);
            if (classifiedAd == null)
            {
                return HttpNotFound();
            }
            return View(classifiedAd);
        }

        // POST: ClassifiedAds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassifiedAdId,IsPublished,IsExpired,CreatedAt,Title,Description")] ClassifiedAd classifiedAd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classifiedAd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classifiedAd);
        }

        // GET: ClassifiedAds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassifiedAd classifiedAd = db.ClassifiedAds.Find(id);
            if (classifiedAd == null)
            {
                return HttpNotFound();
            }
            return View(classifiedAd);
        }

        // POST: ClassifiedAds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassifiedAd classifiedAd = db.ClassifiedAds.Find(id);
            db.ClassifiedAds.Remove(classifiedAd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
