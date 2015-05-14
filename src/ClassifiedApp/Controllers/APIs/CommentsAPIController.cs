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
using Newtonsoft.Json.Linq;

namespace ClassifiedApp.Controllers.APIs
{
    public class CommentsAPIController : ApiController
    {
        private ClassifiedContext db = new ClassifiedContext();

        [Route("ClassifiedAd/{classifiedAdId}/Comments")]
        [HttpGet]
        public IHttpActionResult Comments(int classifiedAdId)
        {
            

            var comments = db.Comments.Where(c => c.ClassifiedAd.ClassifiedAdId == classifiedAdId).Select(comment => new
            {
                comment.Content,
                comment.CreatedAt
            });
            return Ok(comments);
        }

        
        [Route("ClassifiedAd/{classifiedAdId}/Comments")]
        [HttpPost]
        public IHttpActionResult Comments( )
        {
            dynamic obj = Request.Content.ReadAsAsync<JObject>();
            int classifiedAdId = obj.Result.comment.classifiedAdId;
            Comment comment = new Comment();
            comment.Content = obj.Result.comment.content;
            comment.ClassifiedAd = db.ClassifiedAds.Where(c => c.ClassifiedAdId == classifiedAdId).FirstOrDefault();
            db.Comments.Add(comment);
            db.SaveChanges();
            return Ok();
        }


        // GET: api/CommentsAPI
        public IQueryable<Comment> GetComments()
        {
            return db.Comments;
        }

        // GET: api/CommentsAPI/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult GetComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // PUT: api/CommentsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComment(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.CommentId)
            {
                return BadRequest();
            }

            db.Entry(comment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/CommentsAPI
        [ResponseType(typeof(Comment))]
        public IHttpActionResult PostComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Comments.Add(comment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comment.CommentId }, comment);
        }

        // DELETE: api/CommentsAPI/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult DeleteComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            db.Comments.Remove(comment);
            db.SaveChanges();

            return Ok(comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentExists(int id)
        {
            return db.Comments.Count(e => e.CommentId == id) > 0;
        }
    }
}